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
        Debug.Log($"{user.name}�̉�:{target.name}��{healpoint}��:�c���HP{target.hp}");
    }
}