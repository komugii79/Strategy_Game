using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName; // �A�C�e����
    public int cost;        // ���i
    public int statIncrease; // �X�e�[�^�X�㏸��
    public InfoPanelController infoPanelController; // ���p�l���R���g���[��

    private RectTransform rectTransform; // �A�C�e����RectTransform

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // �}�E�X���A�C�e���ɏ�������̏���
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Pointer entered: {itemName}");
        string info = $"{itemName}\n���i: {cost}\n�㏸��: {statIncrease}";
        infoPanelController.ShowInfo(info, rectTransform);
    }

    // �}�E�X���A�C�e�����痣�ꂽ���̏���
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Pointer exited: {itemName}");
        infoPanelController.HideInfo();
    }
}
