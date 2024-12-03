using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;          // ���p�l��
    public TextMeshProUGUI infoText;      // �\������e�L�X�g
    public RectTransform canvasRect;     // �p�l����������Canvas��RectTransform

    // ����\�����A�ʒu�𒲐�
    public void ShowInfo(string info, RectTransform targetTransform)
    {
        // �p�l����\��
        infoPanel.SetActive(true);
        infoText.text = info;

        // �A�C�e���̏㑤�Ƀp�l����z�u
        Vector3 worldPosition = targetTransform.position;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);
        Vector2 worldToCanvasPosition = new Vector2(
            (viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f),
            (viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)
        );

        // ��ɏ����ړ�
        worldToCanvasPosition.y += targetTransform.sizeDelta.y * 0.5f;

        // �p�l���̈ʒu��ݒ�
        infoPanel.GetComponent<RectTransform>().anchoredPosition = worldToCanvasPosition;
    }

    // �����B��
    public void HideInfo()
    {
        infoPanel.SetActive(false); // �p�l�����\��
    }
}