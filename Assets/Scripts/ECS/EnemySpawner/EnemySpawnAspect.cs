using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public readonly partial struct EnemySpawnAspect : IAspect
{
    public readonly Entity Entity;
    private readonly RefRO<EnemySpawnerData> enemySpawnerData;
    private readonly RefRW<SpawnRandom> spawnRandom;

    public int NumberEnemiesToSpawn => enemySpawnerData.ValueRO.maxSpawns;
    public Entity Prefab => enemySpawnerData.ValueRO.prefab;

    public LocalTransform GetRandomSpawnTransform()
    {
        return new LocalTransform
        {

            Position = GetRandomPos(),
            Rotation = quaternion.identity,
            Scale = 1f
        };
    }

    private float3 GetRandomPos()
    {
        float3 randomPosition;
        randomPosition = new float3(spawnRandom.ValueRW.Value.NextFloat(-9, 9), spawnRandom.ValueRW.Value.NextFloat(-5, 5), 0);
        return randomPosition;
    }

}
