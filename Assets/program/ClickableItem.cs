using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public string itemType;
    public int amount = 10;

    private void OnMouseDown()
    {
        // GameManager����ăX�e�[�^�X���X�V����
        GameManager.Instance.UpdateStatus(itemType, amount);
        Debug.Log($"{itemType}��{amount}�����������܂���");
        gameObject.SetActive(false);
    }
}
