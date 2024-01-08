using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;


public struct SpawnRandom : IComponentData
{
    public Random Value;
}
