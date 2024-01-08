using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemySpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
}

class EnemyspawnerBaker : Baker<EnemySpawnerAuthoring>
{
    public override void Bake(EnemySpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);

        // Add the SpawnRandom component to the entity
        AddComponent(entity, new SpawnRandom
        {
            Value = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(1, int.MaxValue))
        });

        AddComponent(entity, new EnemySpawnerData
        {
            prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            spawnPos = authoring.transform.position,
            maxSpawns = 1000,
            currentSpawns = 0,
            spawnRate = 1,
            spawnTimer = 0,
        });
    }
}
