using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} ‚ğ”ñ•\¦‚É‚µ‚Ü‚µ‚½");

        if (targetUI != null)
        {
            targetUI.SetActive(true);
            Debug.Log($"{targetUI.name} ‚ğ•\¦‚µ‚Ü‚µ‚½");
        }
        else
        {
            Debug.LogWarning("targetUI ‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }
}