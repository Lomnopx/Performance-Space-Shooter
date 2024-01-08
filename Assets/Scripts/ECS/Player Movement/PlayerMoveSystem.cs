using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct PlayerMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerMoveSpeed>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (transform, moveInput, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, InputComponent, PlayerMoveSpeed>())
            {
                transform.ValueRW.Position.x += moveInput.Value.x * moveSpeed.Value * deltaTime;
                transform.ValueRW.Position.y += moveInput.Value.y * moveSpeed.Value * deltaTime;
            }
        }
    }
}
