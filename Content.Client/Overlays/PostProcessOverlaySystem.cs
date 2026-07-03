using Content.Shared._FreakyStation.CCVar;
using Robust.Client.Graphics;
using Robust.Shared.Configuration;

namespace Content.Client.Overlays;

/// <summary>
/// Manages the RTX Edition post-processing overlay.
/// Overlay is registered if ANY visual effect is enabled.
/// </summary>
public sealed class PostProcessOverlaySystem : EntitySystem
{
    [Dependency] private readonly IOverlayManager _overlayMan = default!;
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    private PostProcessOverlay? _overlay;

    public override void Initialize()
    {
        base.Initialize();

        _cfg.OnValueChanged(FreakyStationCCVars.BloomEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.ToneMappingEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.VignetteEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.SpecularEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.StreaksEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.FlareEnabled, _ => EnsureOverlay(), true);
        _cfg.OnValueChanged(FreakyStationCCVars.ReflectionEnabled, _ => EnsureOverlay(), true);
    }

    private void EnsureOverlay()
    {
        var anyEnabled =
            _cfg.GetCVar(FreakyStationCCVars.BloomEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.ToneMappingEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.VignetteEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.SpecularEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.StreaksEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.FlareEnabled) ||
            _cfg.GetCVar(FreakyStationCCVars.ReflectionEnabled);

        if (anyEnabled)
        {
            if (_overlay == null)
            {
                _overlay = new PostProcessOverlay();
                _overlayMan.AddOverlay(_overlay);
            }
        }
        else
        {
            if (_overlay != null)
            {
                _overlayMan.RemoveOverlay(_overlay);
                _overlay = null;
            }
        }
    }

    public override void Shutdown()
    {
        base.Shutdown();
        if (_overlay != null)
        {
            _overlayMan.RemoveOverlay(_overlay);
            _overlay = null;
        }
    }
}