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
                battleManager.UpdateBattleLog($"{user.name}�̍U��: {target.name}��{damage}�̃_���[�W! �c���HP: {target.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
            }
        }
        else if (target.block > 0 && attack1 < target.defense)
        {
            damage = target.defense - attack1;
            user.hp -= damage;

            battleManeger battleManager = FindObjectOfType<battleManeger>();
            if (battleManager != null)
            {
                battleManager.UpdateBattleLog($"{target.name}�̃u���b�N: {user.name}��{damage}�̃_���[�W! �c���HP: {user.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
            }
        }
        else
        {
            damage = attack1;
            target.hp -= damage;

            battleManeger battleManager = FindObjectOfType<battleManeger>();
            if (battleManager != null)
            {
                battleManager.UpdateBattleLog($"{user.name}�̍U��2: {target.name}��{damage}�̃_���[�W! �c���HP: {target.hp}");
            }
            else
            {
                Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
            }
        }
        /*
        int damage = user.player == 1 ? GameManager.Instance.attack : user.attack;
        target.hp -= damage;


        battleManeger battleManager = FindObjectOfType<battleManeger>();
        if (battleManager != null )
        {
            battleManager.UpdateBattleLog($"{user.name}�̍U��: {target.name}��{damage}�̃_���[�W! �c���HP: {target.hp}");
        }
        else
        {
            Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
        }*/
    }
}
