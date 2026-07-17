using Robust.Shared.GameObjects;
using Robust.Shared.Timing;
using Robust.Shared.Map;
using Robust.Shared.Serialization.TypeSerializers.Implementations;
using Content.Shared._FreakyStation.Anomaly;

namespace Content.Server._FreakyStation.Anomaly;

public sealed partial class TimeLoopSystem : EntitySystem
{
    [Dependency] private readonly SharedTransformSystem _transformSystem = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IMapManager _map = default!;
    [Dependency] private IEntityManager _entMan = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TimeLoopComponent, ComponentStartup>(OnStartup);
    }

    public void OnStartup(Entity<TimeLoopComponent> entity, ref ComponentStartup args)
    {
        var xform = Transform(entity);
        entity.Comp.Coords = xform.Coordinates;
        entity.Comp.MapId = _transformSystem.GetMapId(xform.Coordinates);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);
        var query = EntityQueryEnumerator<TimeLoopComponent>();
        while (query.MoveNext(out var uid, out var component))
        {
            if (!component.IsActive)
                continue;

            component.TimeLeft -= TimeSpan.FromSeconds(frameTime);

            if (component.TimeLeft <= TimeSpan.Zero)
            {
                var ent = (uid, component);
                TimeLoop(ent);
                component.TimeLeft = component.LoopTime;

            }
        }
    }
    public void TimeLoop(Entity<TimeLoopComponent> ent)
    {
        if (ent.Comp.Coords == null)
            return;

        var xform = Transform(ent);

        if (xform.Deleted || xform.LifeStage > ComponentLifeStage.Running)
            return;

        var curmap = _transformSystem.GetMapId(xform.Coordinates);

        if (curmap != ent.Comp.MapId)
           return;

        var entitycoords = ent.Comp.Coords.Value;

        if (!entitycoords.IsValid(EntityManager))
           return;

        _transformSystem.SetCoordinates(ent, entitycoords);
        _transformSystem.AttachToGridOrMap(ent, xform);
        _entMan.Dirty(ent, xform);
    }
}