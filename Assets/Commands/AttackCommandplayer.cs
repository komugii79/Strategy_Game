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
            battleManager.UpdateBattleLog($"{user.name}�̍U��: {target.name}��{damage}�̃_���[�W! �c���HP: {target.hp}");
        }
        else
        {
            Debug.LogWarning("battleManeger ��������܂���ł����B���O�X�V�ł��܂���B");
        }
    }
}
