
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
            Debug.Log($"{user.name}の攻撃:{target.name}に{GameManager.Instance.attack}のダメージ:残りのHP{target.hp}");
        }
        else
        {
            target.hp -= attack;
            Debug.Log($"{user.name}の攻撃:{target.name}に{attack}のダメージ:残りのHP{target.hp}");
        }
    }
}
