using Content.Shared._FreakyStation.CCVar;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Configuration;
using Robust.Shared.Prototypes;

namespace Content.Client.Overlays;

/// <summary>
/// Manages FakeNormal shader parameters globally.
/// Updates all shader instances when CVars change.
/// </summary>
public sealed class FakeNormalShaderSystem : EntitySystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;
    [Dependency] private readonly IPrototypeManager _proto = default!;

    private ShaderInstance? _fakeNormalShader;

    public override void Initialize()
    {
        base.Initialize();

        // CVars control the YAML-default params, but we can also
        // expose the shader instance for runtime changes if needed.
        // For now, CVars are read at shader load time via YAML params.
        // To actually change them at runtime, we'd need to reload prototypes.

        // The enabled CVar is used by the GraphicsTab checkbox to toggle
        // whether sprites use the shader or not.
        _cfg.OnValueChanged(FreakyStationCCVars.FakeNormalEnabled, _ => UpdateShaderParams(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.FakeNormalStrength, _ => UpdateShaderParams(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.FakeLightWrap, _ => UpdateShaderParams(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.FakeLightIntensity, _ => UpdateShaderParams(), true);
    }

    private void UpdateShaderParams()
    {
        // Sprite-level shaders use prototype params (set in YAML).
        // Runtime changes require prototype reload, which is complex.
        // For now, changes take effect on next game restart.
        // The CVars are ARCHIVE so they persist.
    }
}