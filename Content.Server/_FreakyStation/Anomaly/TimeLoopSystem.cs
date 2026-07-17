using Robust.Shared.GameObjects;
using Robust.Shared.Timing;
using Robust.Shared.Map;
using Content.Shared._FreakyStation.Anomaly;

namespace Content.Server._FreakyStation.Anomaly;

public sealed partial class TimeLoopSystem : EntitySystem
{
    [Dependency] private readonly SharedTransformSystem _transformSystem = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IMapManager _map = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<TimeLoopComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(Entity<TimeLoopComponent> entity, ref ComponentStartup args)
    {
        if (TryComp<TransformComponent>(entity, out var xform))
        {
            entity.Comp.Coords = _transformSystem.GetMapCoordinates(entity);
        }
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

    private void TimeLoop(Entity<TimeLoopComponent> ent)
    {
        var xform = Transform(ent);
        var mapcoords = ent.Comp.Coords;
        var entitycoords = new EntityCoordinates(
       _map.GetMapEntityId(mapcoords.MapId),
            mapcoords.Position
        );
        _transformSystem.SetCoordinates(ent, entitycoords);
        _transformSystem.AttachToGridOrMap(ent, xform);
    }
}