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
                    Debug.Log($"HP��{amount}���₵�܂���!");
                    break;

                case "ATK":
                    playerStatus.AddAttack(amount);
                    Debug.Log($"�U���͂�{amount}���₵�܂���!");
                    break;
                case "DEF":
                    playerStatus.AddDefense(amount);
                    Debug.Log($"�h��͂�{amount}���₵�܂���!");
                    break;
                default:
                    Debug.Log("�s���ȃA�C�e���ł�");
                    break;

            }
        }
        else
        {
            Debug.Log("����������܂���");
        }
    }

}
