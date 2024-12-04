using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastTargetDebugger : MonoBehaviour
{
    void Start()
    {
        // Image�R���|�[�l���g���`�F�b�N
        Image image = GetComponent<Image>();
        if (image != null)
        {
            Debug.Log($"Image Raycast Target: {image.raycastTarget}");
        }

        // Text�R���|�[�l���g���`�F�b�N
        Text text = GetComponent<Text>();
        if (text != null)
        {
            Debug.Log($"Text Raycast Target: {text.raycastTarget}");
        }

        // TextMeshProUGUI�R���|�[�l���g���`�F�b�N
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            Debug.Log($"TextMeshPro Raycast Target: {textMeshPro.raycastTarget}");
        }
    }
}
