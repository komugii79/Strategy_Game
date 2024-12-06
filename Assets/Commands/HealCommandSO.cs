using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int healpoint;

    public override void Execute(Battler user, Battler target)
    {
        target.hp += healpoint;
        Debug.Log($"{user.name}の回復:{target.name}に{healpoint}回復:残りのHP{target.hp}");
    }
}