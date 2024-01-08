using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class EnemyMoveSpeedAuthoring : MonoBehaviour
{
    public float MoveSpeed;
}

public class EnemyAuthoringBaker : Baker<EnemyMoveSpeedAuthoring>
{
    public override void Bake(EnemyMoveSpeedAuthoring authoring)
    {
        var enemyEntity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(enemyEntity, new EnemyMoveSpeed
        {
            Value = authoring.MoveSpeed
        });
        AddComponent<CollisionComponent>(enemyEntity);
        AddComponent<DestroyComponent>(enemyEntity);
    }
}

public partial class EnemyMove : SystemBase
{
    private Entity[] _enemies;
    public Entity _player;
    protected override void OnUpdate()
    {

        var deltaTime = SystemAPI.Time.DeltaTime;

        new EnemyMoveJob
        {
            _playerEntity = _player,
            DeltaTime = deltaTime
        }.ScheduleParallel();


    }
}

[BurstCompile]
public partial struct EnemyMoveJob : IJobEntity
{
    public Entity _playerEntity;
    public float DeltaTime;
    [BurstCompile]
    private void Execute(ref LocalTransform transform, EnemyMoveSpeed speed)
    {
        transform.Position.y -= (speed.Value * DeltaTime);
        if (transform.Position.y < -5)
        {
            transform.Position.y = 20;
        }

    }
}
