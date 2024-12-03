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
        Debug.Log($"{user.name}‚Ì‰ñ•œ:{target.name}‚É{healpoint}‰ñ•œ:Žc‚è‚ÌHP{target.hp}");
    }
}