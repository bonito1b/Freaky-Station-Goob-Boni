

namespace Content.Shared._FreakyStation.Anomaly
{
    [RegisterComponent]
    public partial class DeusExMachinaComponent : Component
    {
        [DataField("desc")]
        public string  desc { get; set; } = string.Empty;

    }
}