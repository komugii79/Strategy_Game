using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public string itemType;
    public int amount = 10;
    public int cost = 20;

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }

    void OnMouseDown()
    {
        if (shopManager != null)
        {
            shopManager.PurchaseItem(itemType, amount,cost);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError($"ShopManager��������܂���");
        }
        /***
        // GameManager����ăX�e�[�^�X���X�V����
        GameManager.Instance.UpdateStatus(itemType, amount);
        Debug.Log($"{itemType}��{amount}�����������܂���");
        gameObject.SetActive(false);
        ***/
    }
}
