#include <napi.h>

#include "zpl_renderer.hpp"

namespace
{
    ZplRenderer renderer;

    Napi::Value Initialize(const Napi::CallbackInfo& info)
    {
        Napi::Env env = info.Env();

        return Napi::Boolean::New(
            env,
            renderer.Initialize());
    }

    Napi::Value GetVersion(const Napi::CallbackInfo& info)
    {
        Napi::Env env = info.Env();

        try
        {
            return Napi::String::New(
                env,
                renderer.GetVersion());
        }
        catch (const std::exception& ex)
        {
            Napi::Error::New(env, ex.what()).ThrowAsJavaScriptException();
            return env.Null();
        }
    }

    Napi::Value Parse(const Napi::CallbackInfo& info)
    {
        Napi::Env env = info.Env();

        if (info.Length() != 1 || !info[0].IsString())
        {
            Napi::TypeError::New(
                env,
                "Expected a ZPL string.")
                .ThrowAsJavaScriptException();

            return env.Null();
        }

        try
        {
            std::string zpl = info[0].As<Napi::String>();

            return Napi::String::New(
                env,
                renderer.Parse(zpl));
        }
        catch (const std::exception& ex)
        {
            Napi::Error::New(env, ex.what()).ThrowAsJavaScriptException();
            return env.Null();
        }
    }

    Napi::Value RenderPng(const Napi::CallbackInfo& info)
    {
        Napi::Env env = info.Env();

        if (info.Length() != 1 || !info[0].IsString())
        {
            Napi::TypeError::New(
                env,
                "Expected a ZPL string.")
                .ThrowAsJavaScriptException();

            return env.Null();
        }

        try
        {
            std::string zpl = info[0].As<Napi::String>();

            std::vector<uint8_t> png =
                renderer.RenderPng(zpl);

            return Napi::Buffer<uint8_t>::Copy(
                env,
                png.data(),
                png.size());
        }
        catch (const std::exception& ex)
        {
            Napi::Error::New(env, ex.what()).ThrowAsJavaScriptException();
            return env.Null();
        }
    }
}

Napi::Object Init(
    Napi::Env env,
    Napi::Object exports)
{
    exports.Set(
        "initialize",
        Napi::Function::New(env, Initialize));

    exports.Set(
        "getVersion",
        Napi::Function::New(env, GetVersion));

    exports.Set(
        "parse",
        Napi::Function::New(env, Parse));

    exports.Set(
        "renderPng",
        Napi::Function::New(env, RenderPng));

    return exports;
}

NODE_API_MODULE(zpl_renderer, Init)