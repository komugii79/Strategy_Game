using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int healpoint;
    [SerializeField] int mppoint;

    public override void Execute(Battler user, Battler target)
    {
        target.hp += healpoint;
        user.mp -= mppoint;
        Debug.Log($"{user.name}の回復:{target.name}に{healpoint}回復:残りのHP{target.hp}");
    }
}