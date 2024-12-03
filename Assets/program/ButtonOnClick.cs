using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} ���\���ɂ��܂���");

        if (targetUI != null)
        {
            targetUI.SetActive(true);
            Debug.Log($"{targetUI.name} ��\�����܂���");
        }
        else
        {
            Debug.LogWarning("targetUI ���ݒ肳��Ă��܂���");
        }
    }
}