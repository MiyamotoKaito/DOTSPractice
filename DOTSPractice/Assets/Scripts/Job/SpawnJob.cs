using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Entities;
using Unity.Burst;

public partial struct SpawnJob : IJobEntity
{
    // ï¿óÒé¿çsópÇÃEntityCommandBuffer
    public EntityCommandBuffer.ParallelWriter ECB;
    void Execute([EntityIndexInChunk] int entityIndex, Entity entity, in SpawnPrefab spawnPrefab)
    {
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                for (int z = 0; z < 100; z++)
                {
                    Entity newEntity = ECB.Instantiate(entityIndex, spawnPrefab._prefab);

                    ECB.SetComponent(entityIndex, newEntity,
                        LocalTransform.FromPosition(new float3(x, y, z) * 1.5f));
                }
            }
        }
        ECB.RemoveComponent<SpawnPrefab>(entityIndex, entity);
    }
}
