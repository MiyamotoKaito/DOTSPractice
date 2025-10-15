using UnityEngine;
using Unity.Entities;

public struct SpawnPrefab : IComponentData
{
    [SerializeField]
    private Entity _prefab;
}
