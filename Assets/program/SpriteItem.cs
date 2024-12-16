using UnityEngine;

public class SpriteItem : MonoBehaviour
{
    public string itemName;          // �A�C�e����
    public int cost;                 // ���i
    public string statType;          // �㏸����X�e�[�^�X�̎�ށi��: "�U����", "�h���"�j
    public int statIncrease;         // �X�e�[�^�X�̏㏸��
    public InfoPanelController infoPanelController; // InfoPanelController�̎Q��

    private void OnMouseEnter()
    {
        // �\����������쐬
        string info = $"{itemName}\n���i: {cost}\n{statType}: +{statIncrease}";

        // �A�C�e����Transform��n���ď���\��
        infoPanelController.ShowInfo(info, transform);
    }

    private void OnMouseExit()
    {
        // ���p�l�����\��
        infoPanelController.HideInfo();
    }
}
