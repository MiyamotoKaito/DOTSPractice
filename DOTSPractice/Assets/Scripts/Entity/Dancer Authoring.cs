using Unity.Entities;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class DancerAuthoring : MonoBehaviour
{
    public float _speed = 1f;

    /// <summary>
    /// Baker��Entitiy��MonoBehaviour��ϊ�
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
/// IComponentData�����������\����
/// ECS�͂��̂悤�ɃR���|�[�l���g���Ƃ̃f�[�^���`����
/// </summary>
public struct Dancer : IComponentData
{
    public float Speed;
}