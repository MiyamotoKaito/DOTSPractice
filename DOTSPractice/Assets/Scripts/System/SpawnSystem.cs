using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Entities;

public partial class SpawnSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSingleton.CreateCommandBuffer(World.Unmanaged).AsParallelWriter();
        
        new SpawnJob()
        {
            ECB = ecb
        }.ScheduleParallel();
    }
}
