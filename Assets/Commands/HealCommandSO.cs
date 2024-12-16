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
        Debug.Log($"{user.name}‚Ì‰ñ•œ:{target.name}‚É{healpoint}‰ñ•œ:Žc‚è‚ÌHP{target.hp}");
    }
}