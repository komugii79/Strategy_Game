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

    //実行するコマンド
    public CommandSO selectCommand;
    public Battler target;

    //持っているコマンド
    public CommandSO[] commands;

    private void Start()
    {
        /*
        if(player == 1)
        {
            // GameManagerから初期ステータスを引き継ぐ
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
                Debug.LogWarning("GameManagerのインスタンスが存在しません！");
            }
        }*/
    }
}
