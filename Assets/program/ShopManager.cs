using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private DebugDisplay logDisplay;   // DebugDisplayへの参照

    private void Start()
    {
        //  DebugDisplayをシーンから取得
        logDisplay = FindObjectOfType<DebugDisplay>();
    }
    public void PurchaseItem(string itemType,int amount,int cost,GameObject itemUI)
    {
        if (GameManager.Instance.playerMoney >= cost)
        {
            GameManager.Instance.UpdateMoney(-cost);
            GameManager.Instance.UpdateStatus(itemType, amount);

            // ポップアップログを表示
            logDisplay.ShowLog($"{itemType}を{amount}Gで購入しました!");

            if (itemUI != null)
            {
                itemUI.SetActive(false);

            }
        }

        else
        {
            // お金が足りない場合のログを表示
            logDisplay.ShowLog("お金が足りません");
        }
    }

}

/***
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
                case "MP":
                    playerStatus.AddMP(amount);
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
***/
