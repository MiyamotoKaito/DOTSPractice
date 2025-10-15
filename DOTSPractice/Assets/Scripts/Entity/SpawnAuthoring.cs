using UnityEngine;
using Unity.Entities;

public class SpawnAuthoring : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    class Baker : Baker<SpawnAuthoring>
    {
        public override void Bake(SpawnAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new SpawnPrefab()
            {
                _prefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}