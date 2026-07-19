#include "zpl_renderer.hpp"

#include <stdexcept>

ZplRenderer::ZplRenderer()
{
}

ZplRenderer::~ZplRenderer()
{
#ifdef _WIN32
    if (_library != nullptr)
    {
        FreeLibrary(_library);
        _library = nullptr;
    }
#endif
}

bool ZplRenderer::Load()
{
#ifdef _WIN32
    if (_library != nullptr)
    {
        return true;
    }

    _library = LoadLibraryA("lib\\ZplRenderer.Core.dll");

if (_library == nullptr)
{
    DWORD error = GetLastError();

    LPSTR message = nullptr;

    FormatMessageA(
        FORMAT_MESSAGE_ALLOCATE_BUFFER |
        FORMAT_MESSAGE_FROM_SYSTEM |
        FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        error,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPSTR)&message,
        0,
        NULL);

    std::string text =
        "Unable to load ZplRenderer.Core.dll.\n";

    text += "Win32 Error: ";
    text += std::to_string(error);

    if (message != nullptr)
    {
        text += "\n";
        text += message;
        LocalFree(message);
    }

    throw std::runtime_error(text);
}

    _initialize = Resolve<InitializeFn>("Initialize");
    _getVersion = Resolve<GetVersionFn>("GetVersion");
    _parse = Resolve<ParseFn>("Parse");
    _renderPng = Resolve<RenderPngFn>("RenderPng");
    _freeMemory = Resolve<FreeMemoryFn>("FreeMemory");

    return _initialize &&
           _getVersion &&
           _parse &&
           _renderPng &&
           _freeMemory;
#else
    return false;
#endif
}

bool ZplRenderer::Initialize()
{
    if (!Load())
    {
        return false;
    }

    return _initialize() == 1;
}

std::string ZplRenderer::GetVersion()
{
    if (!Load())
    {
        throw std::runtime_error("Unable to load ZplRenderer.Core.dll");
    }

    char* value = static_cast<char*>(_getVersion());

    std::string version = value ? value : "";

    _freeMemory(value);

    return version;
}

std::string ZplRenderer::Parse(const std::string& zpl)
{
    if (!Load())
    {
        throw std::runtime_error("Unable to load ZplRenderer.Core.dll");
    }

    char* value = static_cast<char*>(_parse(zpl.c_str()));

    std::string json = value ? value : "";

    _freeMemory(value);

    return json;
}

std::vector<uint8_t> ZplRenderer::RenderPng(const std::string& zpl)
{
    if (!Load())
    {
        throw std::runtime_error("Unable to load ZplRenderer.Core.dll");
    }

    int length = 0;

    uint8_t* data = static_cast<uint8_t*>(
        _renderPng(zpl.c_str(), &length));

    std::vector<uint8_t> png;

    if (data != nullptr && length > 0)
    {
        png.assign(data, data + length);
    }

    _freeMemory(data);

    return png;
}