using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    public new string name;
    public int hp;
    public int mp;
    public int defense;
    public int attack;
    public int money;
    public int block;

    public int player;

    //���s����R�}���h
    public CommandSO selectCommand;
    public Battler target;

    //�����Ă���R�}���h
    public CommandSO[] commands;

    private void Start()
    {
        /*
        if(player == 1)
        {
            // GameManager���珉���X�e�[�^�X�������p��
            if (GameManager.Instance != null)
            {
                hp = GameManager.Instance.hp;
                mp = GameManager.Instance.mp;
                defense = GameManager.Instance.defense;
                attack = GameManager.Instance.attack;
                money = GameManager.Instance.playerMoney;
            }
            else
            {
                Debug.LogWarning("GameManager�̃C���X�^���X�����݂��܂���I");
            }
        }*/
    }
}
