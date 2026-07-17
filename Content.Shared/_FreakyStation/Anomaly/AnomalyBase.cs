
using Content.Shared.Examine;

namespace Content.Shared._FreakyStation.Anomaly;

public abstract partial class AnomalyBaseSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AnomalyItemComponent, ExaminedEvent>(OnExamine);
    }

    public void OnExamine(Entity<AnomalyItemComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString(ent.Comp.desc));
    }
}

