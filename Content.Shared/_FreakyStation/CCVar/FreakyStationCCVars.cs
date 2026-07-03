using Robust.Shared.Configuration;
using Robust.Shared;
namespace Content.Shared._FreakyStation.CCVar;
[CVarDefs]
public sealed class FreakyStationCCVars
{
    // === Visual Enhancements (RTX Edition) ===

    public static readonly CVarDef<bool> BloomEnabled =
        CVarDef.Create("fs.bloom.enabled", true, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomThreshold =
        CVarDef.Create("fs.bloom.threshold", 0.5f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomIntensity =
        CVarDef.Create("fs.bloom.intensity", 1.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> BloomBlurRadius =
        CVarDef.Create("fs.bloom.blur_radius", 2.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> ToneMappingEnabled =
        CVarDef.Create("fs.tonemapping.enabled", true, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> ToneMappingExposure =
        CVarDef.Create("fs.tonemapping.exposure", 2.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> VignetteEnabled =
        CVarDef.Create("fs.vignette.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> VignetteIntensity =
        CVarDef.Create("fs.vignette.intensity", 0.3f, CVar.CLIENTONLY | CVar.ARCHIVE);

    // === Level 8: Fake Specular / RTX Glints (disabled by default - needs tuning) ===

    public static readonly CVarDef<bool> SpecularEnabled =
        CVarDef.Create("fs.specular.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> SpecularIntensity =
        CVarDef.Create("fs.specular.intensity", 0.5f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> StreaksEnabled =
        CVarDef.Create("fs.streaks.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> StreaksIntensity =
        CVarDef.Create("fs.streaks.intensity", 0.4f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> FlareEnabled =
        CVarDef.Create("fs.flare.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> FlareIntensity =
        CVarDef.Create("fs.flare.intensity", 0.3f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> ReflectionEnabled =
        CVarDef.Create("fs.reflection.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> ReflectionIntensity =
        CVarDef.Create("fs.reflection.intensity", 0.25f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<bool> GlintsEnabled =
        CVarDef.Create("fs.glints.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

        // === Fake Normal Lighting ===

    public static readonly CVarDef<bool> FakeNormalEnabled =
        CVarDef.Create("fs.fakenormal.enabled", false, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> FakeNormalStrength =
        CVarDef.Create("fs.fakenormal.strength", 5.0f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> FakeLightWrap =
        CVarDef.Create("fs.fakelight.wrap", 0.3f, CVar.CLIENTONLY | CVar.ARCHIVE);

    public static readonly CVarDef<float> FakeLightIntensity =
        CVarDef.Create("fs.fakelight.intensity", 3.0f, CVar.CLIENTONLY | CVar.ARCHIVE);
// === Debug modes ===

    public static readonly CVarDef<bool> DebugSpecular =
        CVarDef.Create("fs.debug.specular", false, CVar.CLIENTONLY);

    public static readonly CVarDef<bool> DebugGlints =
        CVarDef.Create("fs.debug.glints", false, CVar.CLIENTONLY);

    public static readonly CVarDef<bool> DebugReflections =
        CVarDef.Create("fs.debug.reflections", false, CVar.CLIENTONLY);
}