using Robust.Shared.Configuration;
using Content.Shared.Atmos;
using Robust.Shared;
using System.Runtime.InteropServices.Marshalling;
namespace Content.Shared.ADT.CCVar;
[CVarDefs]
public sealed class ADTCCVars
{
    public static readonly CVarDef<string> HeadshotUrl =
    CVarDef.Create("ic.headshot_url", "", CVar.SERVER | CVar.REPLICATED);

    // === Visual Enhancements (RTX Edition) ===

    public static readonly CVarDef<bool> BloomEnabled =
        CVarDef.Create("adt.bloom.enabled", true, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomThreshold =
        CVarDef.Create("adt.bloom.threshold", 0.5f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomIntensity =
        CVarDef.Create("adt.bloom.intensity", 1.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomBlurRadius =
        CVarDef.Create("adt.bloom.blur_radius", 2.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> ToneMappingEnabled =
        CVarDef.Create("adt.tonemapping.enabled", true, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> ToneMappingExposure =
        CVarDef.Create("adt.tonemapping.exposure", 2.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> VignetteEnabled =
        CVarDef.Create("adt.vignette.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> VignetteIntensity =
        CVarDef.Create("adt.vignette.intensity", 0.3f, CVar.CLIENTONLY | CVar.ARCHIVE);

    // === Level 8: Fake Specular / RTX Glints (disabled by default - needs tuning) ===

    public static readonly CVarDef<bool> SpecularEnabled =
        CVarDef.Create("adt.specular.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> SpecularIntensity =
        CVarDef.Create("adt.specular.intensity", 0.5f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> StreaksEnabled =
        CVarDef.Create("adt.streaks.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> StreaksIntensity =
        CVarDef.Create("adt.streaks.intensity", 0.4f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> FlareEnabled =
        CVarDef.Create("adt.flare.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> FlareIntensity =
        CVarDef.Create("adt.flare.intensity", 0.3f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> ReflectionEnabled =
        CVarDef.Create("adt.reflection.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> ReflectionIntensity =
        CVarDef.Create("adt.reflection.intensity", 0.25f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> GlintsEnabled =
        CVarDef.Create("adt.glints.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    // === Debug modes ===

    public static readonly CVarDef<bool> DebugSpecular =
        CVarDef.Create("adt.debug.specular", false, CVar.CLIENTONLY);

    public static readonly CVarDef<bool> DebugGlints =
        CVarDef.Create("adt.debug.glints", false, CVar.CLIENTONLY);

    public static readonly CVarDef<bool> DebugReflections =
        CVarDef.Create("adt.debug.reflections", false, CVar.CLIENTONLY);
}