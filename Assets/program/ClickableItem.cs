using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public string itemType;
    public int amount = 10;

    private void OnMouseDown()
    {
        // GameManagerを介してステータスを更新する
        GameManager.Instance.UpdateStatus(itemType, amount);
        Debug.Log($"{itemType}を{amount}だけ増加しました");
        gameObject.SetActive(false);
    }
}
