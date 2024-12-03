using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnClickAttack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetUI;
    private battleManeger battleManager;

    void Start()
    {
        // battleManeger を自動的に取得する
        battleManager = FindObjectOfType<battleManeger>();
        if (battleManager == null)
        {
            Debug.LogWarning("battleManager がシーン内に見つかりませんでした");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} を非表示にしました");
        if (battleManager != null)
        {
            // PhaseをExecutePhaseに変更
            battleManager.ChangePhaseToExecute();
        }
        else
        {
            Debug.LogWarning("battleManager が設定されていません");
        }

    }
}
