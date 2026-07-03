using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.Prototypes;
using Robust.Shared.Configuration;
using Content.Shared._FreakyStation.CCVar;

namespace Content.Client.Overlays;

/// <summary>
/// RTX Edition combined post-processing overlay.
/// Bloom + Tone Mapping + Vignette/Fake AO + Fake Specular + Light Streaks + Lens Flare + Floor Reflection.
/// All effects in single shader pass, each toggleable via CVars.
/// </summary>
public sealed class PostProcessOverlay : Overlay
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    private readonly ShaderInstance _postProcessShader;

    public override OverlaySpace Space => OverlaySpace.WorldSpace;
    public override bool RequestScreenTexture => true;

    // Bloom
    private bool _bloomEnabled = true;
    private float _bloomThreshold = 0.7f;
    private float _bloomIntensity = 0.8f;
    private float _bloomBlurRadius = 2.0f;

    // Tone mapping
    private bool _toneMappingEnabled = true;
    private float _toneMappingExposure = 1.0f;

    // Vignette
    private bool _vignetteEnabled = true;
    private float _vignetteIntensity = 0.3f;

    // Specular
    private bool _specularEnabled = true;
    private float _specularIntensity = 0.5f;

    // Streaks
    private bool _streaksEnabled = true;
    private float _streaksIntensity = 0.4f;

    // Flare
    private bool _flareEnabled = true;
    private float _flareIntensity = 0.3f;

    // Reflection
    private bool _reflectionEnabled = true;
    private float _reflectionIntensity = 0.25f;

    // Debug
    private bool _debugSpecular;
    private bool _debugGlints;
    private bool _debugReflections;

    public PostProcessOverlay()
    {
        IoCManager.InjectDependencies(this);

        _postProcessShader = _prototypeManager.Index<ShaderPrototype>("PostProcess").InstanceUnique();

        // Bloom
        _cfg.OnValueChanged(FreakyStationCCVars.BloomEnabled, v => _bloomEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.BloomThreshold, v => _bloomThreshold = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.BloomIntensity, v => _bloomIntensity = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.BloomBlurRadius, v => _bloomBlurRadius = v, true);

        // Tone mapping
        _cfg.OnValueChanged(FreakyStationCCVars.ToneMappingEnabled, v => _toneMappingEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.ToneMappingExposure, v => _toneMappingExposure = v, true);

        // Vignette
        _cfg.OnValueChanged(FreakyStationCCVars.VignetteEnabled, v => _vignetteEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.VignetteIntensity, v => _vignetteIntensity = v, true);

        // Specular
        _cfg.OnValueChanged(FreakyStationCCVars.SpecularEnabled, v => _specularEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.SpecularIntensity, v => _specularIntensity = v, true);

        // Streaks
        _cfg.OnValueChanged(FreakyStationCCVars.StreaksEnabled, v => _streaksEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.StreaksIntensity, v => _streaksIntensity = v, true);

        // Flare
        _cfg.OnValueChanged(FreakyStationCCVars.FlareEnabled, v => _flareEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.FlareIntensity, v => _flareIntensity = v, true);

        // Reflection
        _cfg.OnValueChanged(FreakyStationCCVars.ReflectionEnabled, v => _reflectionEnabled = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.ReflectionIntensity, v => _reflectionIntensity = v, true);

        // Debug
        _cfg.OnValueChanged(FreakyStationCCVars.DebugSpecular, v => _debugSpecular = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.DebugGlints, v => _debugGlints = v, true);
        _cfg.OnValueChanged(FreakyStationCCVars.DebugReflections, v => _debugReflections = v, true);

        ZIndex = 100;
    }

    protected override void Draw(in OverlayDrawArgs args)
    {
        if (ScreenTexture == null)
            return;

        var handle = args.WorldHandle;

        _postProcessShader.SetParameter("SCREEN_TEXTURE", ScreenTexture);

        // Bloom (disabled = threshold 2.0 so nothing passes)
        _postProcessShader.SetParameter("BLOOM_THRESHOLD", _bloomEnabled ? _bloomThreshold : 2.0f);
        _postProcessShader.SetParameter("BLOOM_INTENSITY", _bloomEnabled ? _bloomIntensity : 0.0f);
        _postProcessShader.SetParameter("BLUR_RADIUS", _bloomBlurRadius);

        // Tone mapping (1.0 = neutral)
        _postProcessShader.SetParameter("EXPOSURE", _toneMappingEnabled ? _toneMappingExposure : 1.0f);

        // Vignette (0 = off)
        _postProcessShader.SetParameter("VIGNETTE_INTENSITY", _vignetteEnabled ? _vignetteIntensity : 0.0f);

        // Specular
        var specIntensity = _specularEnabled ? _specularIntensity : 0.0f;
        if (_debugSpecular) specIntensity = 1.0f; // Debug: max intensity
        _postProcessShader.SetParameter("SPECULAR_INTENSITY", specIntensity);

        // Streaks
        _postProcessShader.SetParameter("STREAK_INTENSITY", _streaksEnabled ? _streaksIntensity : 0.0f);

        // Flare
        _postProcessShader.SetParameter("FLARE_INTENSITY", _flareEnabled ? _flareIntensity : 0.0f);

        // Reflection
        var reflIntensity = _reflectionEnabled ? _reflectionIntensity : 0.0f;
        if (_debugReflections) reflIntensity = 0.8f; // Debug: boosted
        _postProcessShader.SetParameter("REFLECTION_INTENSITY", reflIntensity);

        handle.UseShader(_postProcessShader);
        handle.DrawRect(args.WorldBounds, Color.White);
        handle.UseShader(null);
    }
}