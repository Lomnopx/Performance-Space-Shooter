using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class BulletLifteTimeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var ecb = new EntityCommandBuffer(Allocator.TempJob);
        var deltaTime = SystemAPI.Time.DeltaTime;

        Entities.ForEach((Entity entity, ref Lifetime lifetime) =>
        {
            lifetime.Value -= deltaTime;
            if (lifetime.Value <= 0f)
            {
                ecb.DestroyEntity(entity);
            }
        }).Run();

        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}