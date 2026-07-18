#pragma once

#include <string>
#include <vector>

#ifdef _WIN32
#include <Windows.h>
#endif

class ZplRenderer
{
public:
    ZplRenderer();
    ~ZplRenderer();
    bool Initialize();

    std::string GetVersion();

    std::string Parse(const std::string& zpl);

    std::vector<uint8_t> RenderPng(const std::string& zpl);

private:
#ifdef _WIN32
    HMODULE _library = nullptr;
#endif

    typedef int (*InitializeFn)();
    typedef void* (*GetVersionFn)();
    typedef void* (*ParseFn)(const char*);
    typedef void* (*RenderPngFn)(const char*, int*);
    typedef void (*FreeMemoryFn)(void*);

    InitializeFn _initialize = nullptr;
    GetVersionFn _getVersion = nullptr;
    ParseFn _parse = nullptr;
    RenderPngFn _renderPng = nullptr;
    FreeMemoryFn _freeMemory = nullptr;

    bool Load();

    template<typename T>
    T Resolve(const char* name)
    {
#ifdef _WIN32
        return reinterpret_cast<T>(GetProcAddress(_library, name));
#else
        return nullptr;
#endif
    }
};