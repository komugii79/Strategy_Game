using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;          // 情報パネル
    public TextMeshProUGUI infoText;      // 表示するテキスト
    public RectTransform canvasRect;     // パネルが属するCanvasのRectTransform

    // 情報を表示し、位置を調整
    public void ShowInfo(string info, RectTransform targetTransform)
    {
        // パネルを表示
        infoPanel.SetActive(true);
        infoText.text = info;

        // アイテムの上側にパネルを配置
        Vector3 worldPosition = targetTransform.position;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);
        Vector2 worldToCanvasPosition = new Vector2(
            (viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f),
            (viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)
        );

        // 上に少し移動
        worldToCanvasPosition.y += targetTransform.sizeDelta.y * 0.5f;

        // パネルの位置を設定
        infoPanel.GetComponent<RectTransform>().anchoredPosition = worldToCanvasPosition;
    }

    // 情報を隠す
    public void HideInfo()
    {
        infoPanel.SetActive(false); // パネルを非表示
    }
}