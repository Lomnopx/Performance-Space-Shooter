using Unity.Entities;
using Unity.Burst;

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

            // Spawn a new entity if the spawn timer is greater than or equal to the spawn rate
            if (spawner.ValueRO.spawnTimer >= spawner.ValueRO.spawnRate)
            {
                SpawnEnemy(ref spawner, ref state);
            }
        }

        public void SpawnEnemy(ref RefRW<EnemySpawnerData> spawner, ref SystemState state)
        {
            var ECB = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

            var enemyEntity = SystemAPI.GetSingletonEntity<EnemySpawnerData>();
            var enemyAspect = SystemAPI.GetAspect<EnemySpawnAspect>(enemyEntity);

            for (var i = 0; i < enemyAspect.NumberEnemiesToSpawn; i++)
            {
                var newEnemy = ECB.Instantiate(enemyAspect.Prefab);
                var newEnemyTransform = enemyAspect.GetRandomSpawnTransform();
                ECB.SetComponent(newEnemy, newEnemyTransform);
                ECB.AddComponent<CollisionComponent>(newEnemy);
                ECB.AddComponent<DestroyComponent>(newEnemy);
                ECB.AddComponent(newEnemy, new Lifetime { Value = 30f });
            }
            // Reset the spawn timer
            spawner.ValueRW.spawnTimer = 0f;
        }
    }
}



