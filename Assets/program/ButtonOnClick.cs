using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} を非表示にしました");

        if (targetUI != null)
        {
            targetUI.SetActive(true);
            Debug.Log($"{targetUI.name} を表示しました");
        }
        else
        {
            Debug.LogWarning("targetUI が設定されていません");
        }
    }
}