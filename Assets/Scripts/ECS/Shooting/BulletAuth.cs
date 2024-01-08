using Unity.Entities;
using UnityEngine;

public class ProjectileMoveSpeedAuthoring : MonoBehaviour
{
    public float ProjectileMoveSpeed;
    public Entity entity;
    public class ProjectileMoveSpeedBaker : Baker<ProjectileMoveSpeedAuthoring>
    {
        public override void Bake(ProjectileMoveSpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ProjectileMoveSpeed { Value = authoring.ProjectileMoveSpeed });
        }
    }
}
