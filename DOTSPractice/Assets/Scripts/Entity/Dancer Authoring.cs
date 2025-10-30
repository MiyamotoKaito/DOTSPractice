using Unity.Entities;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class DancerAuthoring : MonoBehaviour
{
    public float _speed = 1f;

    /// <summary>
    /// BakerでEntitiyにMonoBehaviourを変換
    /// </summary>
    class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring src)
        {
            var data = new Dancer() { Speed = src._speed };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
/// <summary>
/// IComponentDataを実装した構造体
/// ECSはこのようにコンポーネントごとのデータを定義する
/// </summary>
public struct Dancer : IComponentData
{
    public float Speed;
}