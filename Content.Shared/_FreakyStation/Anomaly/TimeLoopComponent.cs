
using Robust.Shared.Map;
using Robust.Shared.GameStates;

namespace Content.Shared._FreakyStation.Anomaly;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public partial class TimeLoopComponent : Component
{
    [DataField, AutoNetworkedField]
    public MapCoordinates Coords;

    [ViewVariables]
    public bool IsActive = true;

    [DataField, AutoNetworkedField]
    public TimeSpan TimeLeft = TimeSpan.FromSeconds(30);

    [DataField, AutoNetworkedField]
    public TimeSpan LoopTime = TimeSpan.FromSeconds(30);


}
