using System.Collections;
using System.Collections.Generic;
using Unity.Entities;


public struct Pool : IComponentData
{
    public DynamicBuffer<EntityElement> Entities;
}
public struct EntityElement : IBufferElementData
{
    public Entity Value;
}
