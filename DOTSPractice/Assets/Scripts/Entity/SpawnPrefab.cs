using UnityEngine;
using Unity.Entities;

public struct SpawnPrefab : IComponentData
{
    [SerializeField]
    public Entity _prefab;
}
