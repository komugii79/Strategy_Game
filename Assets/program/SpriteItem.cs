using UnityEngine;

public class SpriteItem : MonoBehaviour
{
    public string itemName;          // アイテム名
    public int cost;                 // 価格
    public string statType;          // 上昇するステータスの種類（例: "攻撃力", "防御力"）
    public int statIncrease;         // ステータスの上昇量
    public InfoPanelController infoPanelController; // InfoPanelControllerの参照

    private void OnMouseEnter()
    {
        // 表示する情報を作成
        string info = $"{itemName}\n価格: {cost}\n{statType}: +{statIncrease}";

        // アイテムのTransformを渡して情報を表示
        infoPanelController.ShowInfo(info, transform);
    }

    private void OnMouseExit()
    {
        // 情報パネルを非表示
        infoPanelController.HideInfo();
    }
}
