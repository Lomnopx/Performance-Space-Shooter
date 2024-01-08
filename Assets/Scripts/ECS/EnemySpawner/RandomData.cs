using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct RandomData : IComponentData
{
    public Unity.Mathematics.Random Value;
}
