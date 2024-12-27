using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandplayer : CommandSO
{
    [SerializeField] int attack;

    public override void Execute(Battler user, Battler target)
    {
        int attack1 = user.player == 1 ? GameManager.Instance.attack : user.attack;
        int damage;
        if (target.block > 0 && attack1 >= target.defense)
        {
            damage = attack1 - target.defense;
            target.hp -= damage;

            battleManeger battleManager = FindObjectOfType<battleManeger>();
            if (battleManager != null)
            {
                battleManager.UpdateBattleLog($"{user.name}の攻撃: {target.name}に{damage}のダメージ! 残りのHP: {target.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger が見つかりませんでした。ログ更新できません。");
            }
        }
        else if (target.block > 0 && attack1 < target.defense)
        {
            damage = target.defense - attack1;
            user.hp -= damage;

            battleManeger battleManager = FindObjectOfType<battleManeger>();
            if (battleManager != null)
            {
                battleManager.UpdateBattleLog($"{target.name}のブロック: {user.name}に{damage}のダメージ! 残りのHP: {user.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger が見つかりませんでした。ログ更新できません。");
            }
        }
        else
        {
            damage = attack1;
            target.hp -= damage;

            battleManeger battleManager = FindObjectOfType<battleManeger>();
            if (battleManager != null)
            {
                battleManager.UpdateBattleLog($"{user.name}の攻撃2: {target.name}に{damage}のダメージ! 残りのHP: {target.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger が見つかりませんでした。ログ更新できません。");
            }
        }
        /*
        int damage = user.player == 1 ? GameManager.Instance.attack : user.attack;
        target.hp -= damage;


        battleManeger battleManager = FindObjectOfType<battleManeger>();
        if (battleManager != null )
        {
            battleManager.UpdateBattleLog($"{user.name}の攻撃: {target.name}に{damage}のダメージ! 残りのHP: {target.hp}");
        }
        else
        {
            Debug.LogWarning("battleManeger が見つかりませんでした。ログ更新できません。");
        }*/
    }
}
