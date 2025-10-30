using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// 処理の部分
/// C#だと自動で補助的なコード達が生成されるためPartialにして共存させる
/// SourceGenerators
/// </summary>
public partial struct DancerSystm : ISystem
{
    //OnUpdateに更新処理を記述
    public void OnUpdate(ref SystemState state)
    {
        //現在の経過時間をSystemAPIから取得
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        //DancerとLocalTransformを持っているエンティティを列挙する
        //RefRO値を書き換えない参照の場合(ReadOnly)
        //RefRW値を書き換える参照の場合(ReadWrite)
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
