
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectableText : Selectable
{
    public int commandIndex; // このテキストが対応するコマンドのインデックス
    private battleManeger battleManager; // battleManagerへの参照

    protected override void Start()
    {
        base.Start();
        battleManager = FindObjectOfType<battleManeger>(); // battleManagerを取得
        if (battleManager == null)
        {
            Debug.LogError("battleManegerが見つかりません。シーンに配置されていることを確認してください。");
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);

        if (battleManager != null)
        {
            // コマンドインデックスを設定
            battleManager.SelectCommand(commandIndex);
            Debug.Log($"コマンド {commandIndex} が選択されました: {gameObject.name}");

            // フェーズを変更
            battleManager.ChangePhaseToExecute();

            // 選択解除を確実に実行
            StartCoroutine(DeselectAfterFrame());
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name} の選択が解除されました");
    }

    private IEnumerator DeselectAfterFrame()
    {
        // 次のフレームまで待機
        yield return null;

        // 選択解除
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log("選択解除が実行されました");
    }
}
