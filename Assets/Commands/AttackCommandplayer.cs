using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandplayer : CommandSO
{
    [SerializeField] int attack;

    public override void Execute(Battler user, Battler target)
    {
        /*
        int attack1 = user.player == 1 ? GameManager.Instance.attack : attack;
        int damage;
        if (target.block > 0 && attack1 > target.defense * 2)
        {
            damage = attack1 - target.defense * 2;
            target.hp -= damage;
        }
        else if(target.block == 0 )
        {
            damage = attack1;
            target.hp -= damage;
        }
        else
        {
            damage = 0;
        }*/

        int damage = user.player == 1 ? GameManager.Instance.attack : attack;
        target.hp -= damage;



        battleManeger battleManager = FindObjectOfType<battleManeger>();
        if (battleManager != null )
        {
            battleManager.UpdateBattleLog($"{user.name}の攻撃: {target.name}に{damage}のダメージ! 残りのHP: {target.hp}");
        }
        else
        {
            Debug.LogWarning("battleManeger が見つかりませんでした。ログ更新できません。");
        }
    }
}
