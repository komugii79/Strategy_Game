using TMPro;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;          // 情報パネル
    public TextMeshProUGUI infoText;      // 表示するテキスト
    public RectTransform canvasRect;     // パネルが属するCanvasのRectTransform

    // 情報を表示し、位置を調整
    public void ShowInfo(string info, Transform targetTransform)
    {
        // パネルを表示
        infoPanel.SetActive(true);
        infoText.text = info;

        // アイテムのワールド座標を取得
        Vector3 worldPosition = targetTransform.position;

        // カメラでワールド座標をビューポート座標に変換
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);

        // ビューポート座標をCanvas内の座標に変換
        Vector2 worldToCanvasPosition = new Vector2(
            (viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f),
            (viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)
        );

        // 上に少し移動
        worldToCanvasPosition.y += 50f; // 必要に応じて調整可能

        // パネルの位置を設定
        infoPanel.GetComponent<RectTransform>().anchoredPosition = worldToCanvasPosition;
    }

    // 情報を隠す
    public void HideInfo()
    {
        infoPanel.SetActive(false); // パネルを非表示
    }
}
