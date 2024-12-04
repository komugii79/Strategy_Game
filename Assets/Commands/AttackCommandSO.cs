
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int attack;

    public override void Execute(Battler user, Battler target)
    {
        target.hp -= attack;
        Debug.Log($"{user.name}の攻撃:{target.name}に{attack}のダメージ:残りのHP{target.hp}");
    }
}
