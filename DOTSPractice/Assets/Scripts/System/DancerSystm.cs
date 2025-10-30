using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// �����̕���
/// C#���Ǝ����ŕ⏕�I�ȃR�[�h�B����������邽��Partial�ɂ��ċ���������
/// SourceGenerators
/// </summary>
public partial struct DancerSystm : ISystem
{
    //OnUpdate�ɍX�V�������L�q
    public void OnUpdate(ref SystemState state)
    {
        //���݂̌o�ߎ��Ԃ�SystemAPI����擾
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        //Dancer��LocalTransform�������Ă���G���e�B�e�B��񋓂���
        //RefRO�l�����������Ȃ��Q�Ƃ̏ꍇ(ReadOnly)
        //RefRW�l������������Q�Ƃ̏ꍇ(ReadWrite)
        foreach (var (dancer, xform) in
            SystemAPI.Query<RefRO<Dancer>,
                            RefRW<LocalTransform>>())
        {
            var t = dancer.ValueRO.Speed * elapsed;
            var y = Math.Abs(math.sin(t)) * 0.1f;
            var bank = math.cos(t) * 0.5f;

            var fwd = xform.ValueRO.Forward();
            var rot = quaternion.AxisAngle(fwd, bank);
            var up = math.mul(rot, math.float3(0, 1, 0));

            xform.ValueRW.Position.y = y;
            xform.ValueRW.Rotation = quaternion.LookRotation(fwd, up);
        }
    }
}
