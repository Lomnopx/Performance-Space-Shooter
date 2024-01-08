using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class PlayerMoveSystemNew : SystemBase
    {
        protected override void OnUpdate()
        {
            // Your system implementation here
        }
    }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(PlayerMoveSystemNew))]
    public partial class CollisionSystemNew : SystemBase
    {
        protected override void OnUpdate()
        {
            // Your system implementation here
        }
    }
    public struct CollisionComponent : IComponentData { }

    public struct DestroyComponent : IComponentData { }
}


