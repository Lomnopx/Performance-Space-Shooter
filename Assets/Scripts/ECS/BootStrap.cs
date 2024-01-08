using ECS;
using Unity.Entities;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        // Get the default world
        var world = World.DefaultGameObjectInjectionWorld;

        // Create your systems
        var playerMoveSystem = world.GetOrCreateSystem<PlayerMoveSystem>();
        var collisionSystem = world.GetOrCreateSystem<CollisionSystem>();
    }
}