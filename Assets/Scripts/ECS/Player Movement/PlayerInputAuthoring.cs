using Unity.Entities;
using UnityEngine;

public class PlayerInputAuthoring : MonoBehaviour
{
    public float MoveSpeed=2;
}

public class PlayerInputAuthoringBaker : Baker<PlayerInputAuthoring>
{
    public override void Bake(PlayerInputAuthoring authoring)
    {
        var playerEntity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent<InputComponent>(playerEntity);
        AddComponent<DestroyComponent>(playerEntity);
        AddComponent<CollisionComponent>(playerEntity);
        AddComponent(playerEntity, new PlayerMoveSpeed
        {
            Value = authoring.MoveSpeed
        });
    }
}
