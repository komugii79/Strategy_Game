using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastTargetDebugger : MonoBehaviour
{
    void Start()
    {
        // Imageコンポーネントをチェック
        Image image = GetComponent<Image>();
        if (image != null)
        {
            Debug.Log($"Image Raycast Target: {image.raycastTarget}");
        }

        // Textコンポーネントをチェック
        Text text = GetComponent<Text>();
        if (text != null)
        {
            Debug.Log($"Text Raycast Target: {text.raycastTarget}");
        }

        // TextMeshProUGUIコンポーネントをチェック
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            Debug.Log($"TextMeshPro Raycast Target: {textMeshPro.raycastTarget}");
        }
    }
}
