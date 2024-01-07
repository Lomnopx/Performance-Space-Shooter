using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct Position : IComponentData
{
    public Unity.Mathematics.float3 Value;
}
