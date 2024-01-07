using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

namespace ECS
{
    //[BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct EnemySpawner : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemySpawnerData>();
        }

        //[BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            if (!SystemAPI.TryGetSingletonEntity<EnemySpawnerData>(out Entity spawnerEntity))
            {
                return;
            }

            RefRW<EnemySpawnerData> spawner = SystemAPI.GetComponentRW<EnemySpawnerData>(spawnerEntity);

            // Update the spawn timer
            spawner.ValueRW.spawnTimer += deltaTime;

            // Only spawn a new entity if the spawn timer is greater than or equal to the spawn rate
            if (spawner.ValueRO.currentSpawns < spawner.ValueRO.maxSpawns && spawner.ValueRO.spawnTimer >= spawner.ValueRO.spawnRate)
            {
                var ECB = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

                var enemyEntity = SystemAPI.GetSingletonEntity<EnemySpawnerData>();
                var enemyAspect = SystemAPI.GetAspect<EnemySpawnAspect>(enemyEntity);


                for (var i = 0; i < enemyAspect.NumberEnemiesToSpawn; i++)
                {
                    var newEnemy = ECB.Instantiate(enemyAspect.Prefab);
                    var newEnemyTransform = enemyAspect.GetRandomSpawnTransform();
                    ECB.SetComponent(newEnemy, newEnemyTransform);
                    spawner.ValueRW.currentSpawns++;
                }
                // Reset the spawn timer and increment the current spawns
                spawner.ValueRW.spawnTimer = 0f;
                spawner.ValueRW.currentSpawns++;
            }
        }
    }

}



