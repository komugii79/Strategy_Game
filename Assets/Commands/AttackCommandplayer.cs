
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandplayer : CommandSO
{
    [SerializeField] int attack;

    public override void Execute(Battler user, Battler target)
    {
        if(user.player == 1)
        {
            target.hp -= GameManager.Instance.attack;
            Debug.Log($"{user.name}�̍U��:{target.name}��{GameManager.Instance.attack}�̃_���[�W:�c���HP{target.hp}");
        }
        else
        {
            target.hp -= attack;
            Debug.Log($"{user.name}�̍U��:{target.name}��{attack}�̃_���[�W:�c���HP{target.hp}");
        }
    }
}
