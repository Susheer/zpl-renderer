#include <napi.h>

#include "zpl_renderer.hpp"

namespace
{
    ZplRenderer renderer;

    Napi::Value JsInitialize(const Napi::CallbackInfo& info)
    {
    Napi::Env env = info.Env();
        try{

        return Napi::Boolean::New(env, renderer.Initialize());
        }catch(const std::exception& ex){
            Napi::Error::New(env, ex.what()).ThrowAsJavaScriptException();
            return env.Null();
        }
    }

    Napi::Value JsGetVersion(const Napi::CallbackInfo& info)
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

    Napi::Value JsParse(const Napi::CallbackInfo& info)
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

    Napi::Value JsRenderPng(const Napi::CallbackInfo& info)
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
        Napi::Function::New(env, JsInitialize));

    exports.Set(
        "getVersion",
        Napi::Function::New(env, JsGetVersion));

    exports.Set(
        "parse",
        Napi::Function::New(env, JsParse));

    exports.Set(
        "renderPng",
        Napi::Function::New(env, JsRenderPng));

    return exports;
}

NODE_API_MODULE(zpl_renderer, Init)