using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName; // アイテム名
    public int cost;        // 価格
    public int statIncrease; // ステータス上昇量
    public InfoPanelController infoPanelController; // 情報パネルコントローラ

    private RectTransform rectTransform; // アイテムのRectTransform

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // マウスがアイテムに乗った時の処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Pointer entered: {itemName}");
        string info = $"{itemName}\n価格: {cost}\n上昇量: {statIncrease}";
        infoPanelController.ShowInfo(info, rectTransform);
    }

    // マウスがアイテムから離れた時の処理
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Pointer exited: {itemName}");
        infoPanelController.HideInfo();
    }
}
