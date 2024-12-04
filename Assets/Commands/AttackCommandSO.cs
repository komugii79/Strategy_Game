
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
        Debug.Log($"{user.name}�̍U��:{target.name}��{attack}�̃_���[�W:�c���HP{target.hp}");
    }
}
