using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private DebugDisplay logDisplay;   // DebugDisplay�ւ̎Q��

    private void Start()
    {
        //  DebugDisplay���V�[������擾
        logDisplay = FindObjectOfType<DebugDisplay>();
    }
    public void PurchaseItem(string itemType,int amount,int cost,GameObject itemUI)
    {
        if (GameManager.Instance.playerMoney >= cost)
        {
            GameManager.Instance.UpdateMoney(-cost);
            GameManager.Instance.UpdateStatus(itemType, amount);

            // �|�b�v�A�b�v���O��\��
            logDisplay.ShowLog($"{itemType}��{amount}G�ōw�����܂���!");

            if (itemUI != null)
            {
                itemUI.SetActive(false);

            }
        }

        else
        {
            // ����������Ȃ��ꍇ�̃��O��\��
            logDisplay.ShowLog("����������܂���");
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
                case "MP":
                    playerStatus.AddMP(amount);
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
***/
