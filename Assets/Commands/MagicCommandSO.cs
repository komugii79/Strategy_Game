using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int mp;
    
    public override void Execute(Battler user, Battler target)
    {
        int damage = user.player == 1 ? (user.mp / 2) : mp;
        target.hp -= damage;
        user.mp /= 2;

        battleManeger battleManager = FindObjectOfType<battleManeger>();
        if (battleManager != null)
        {
            battleManager.UpdateBattleLog($"{user.name}�̖��@: {target.name}��{damage}�̃_���[�W! �c���HP: {target.hp}");
            if (user.player == 1)
            {
                battleManager.UpdateEnemyDamageLog($"{-damage}");
            }
            else
            {
                battleManager.UpdatePlayerDamageLog($"{-damage}");
            }
        }
        else
        {
            Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
        }
    }
}
