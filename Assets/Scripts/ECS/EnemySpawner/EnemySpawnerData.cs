using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Entities;
using Unity.Mathematics;



public struct EnemySpawnerData : IComponentData
{
    public Entity prefab;
    public float3 spawnPos;
    public int maxSpawns;
    public int currentSpawns;
    public float spawnRate;
    public float spawnTimer;
}
