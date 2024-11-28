using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerStatus playerStatus;

    public void PurchaseItem(string itemType,int amount,int cost,ref int playerMoney)
    {
        if(playerMoney >= cost)
        {
            playerMoney -= cost;

            switch (itemType)
            {
                case "HP":
                    playerStatus.AddHP(amount);
                    Debug.Log($"HPを{amount}増やしました!");
                    break;

                case "ATK":
                    playerStatus.AddAttack(amount);
                    Debug.Log($"攻撃力を{amount}増やしました!");
                    break;
                case "DEF":
                    playerStatus.AddDefense(amount);
                    Debug.Log($"防御力を{amount}増やしました!");
                    break;
                default:
                    Debug.Log("不明なアイテムです");
                    break;

            }
        }
        else
        {
            Debug.Log("お金が足りません");
        }
    }

}
