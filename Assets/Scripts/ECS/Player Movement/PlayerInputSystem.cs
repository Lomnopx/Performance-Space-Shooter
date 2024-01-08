using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Entities.ForEach((ref InputComponent input) =>
        {
            input.Value = new float2(horizontalInput, verticalInput);
        }).ScheduleParallel();
    }
}