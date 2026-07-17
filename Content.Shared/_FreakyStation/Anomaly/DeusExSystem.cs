
using Content.Shared._FreakyStation.Anomaly;
using Content.Shared.Popups;
using Content.Shared.Interaction.Events;

namespace Content.Shared._Freakystation.Anomaly;

public sealed partial class DeusExMachineSystem : AnomalyBaseSystem
{
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DeusExMachinaComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<DeusExMachinaComponent, UseInHandEvent>(OnUse);

    }
    public void OnStartup(Entity<DeusExMachinaComponent> ent, ref ComponentStartup args)
    {
      EnsureComp<AnomalyItemComponent>(ent);
    }
    public void OnUse(Entity<DeusExMachinaComponent> ent, ref UseInHandEvent args)
    {
       EnsureComp<TimeLoopComponent>(args.User);
       _popup.PopupEntity(Loc.GetString("anomaly-item-user"), args.User);
    }

}