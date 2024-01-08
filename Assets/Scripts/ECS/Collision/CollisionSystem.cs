using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Collections;


namespace ECS
{
    [BurstCompile]
    public partial struct CollisionSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndVariableRateSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<SimulationSingleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = SystemAPI.GetSingleton<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>();
            state.Dependency = new CollisionEvent
            {
                CollisionLookup = SystemAPI.GetComponentLookup<CollisionComponent>(),
                DestroyLookup = SystemAPI.GetComponentLookup<DestroyComponent>(),
                ECB = ecb.CreateCommandBuffer(state.WorldUnmanaged)
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);
        }
    }

    [BurstCompile]
    public struct CollisionEvent : ICollisionEventsJob
    {
        [ReadOnly] public ComponentLookup<CollisionComponent> CollisionLookup;
        [ReadOnly] public ComponentLookup<DestroyComponent> DestroyLookup;
        public EntityCommandBuffer ECB;

        [BurstCompile]
        public void Execute(Unity.Physics.CollisionEvent collisionEvent)
        {
            if (DestroyLookup.HasComponent(collisionEvent.EntityA))
            {
                ECB.DestroyEntity(collisionEvent.EntityA);
            }

            if (DestroyLookup.HasComponent(collisionEvent.EntityB))
            {
                ECB.DestroyEntity(collisionEvent.EntityB);
            }
        }
    }
}