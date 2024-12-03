using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnClickAttack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetUI;
    private battleManeger battleManager;

    void Start()
    {
        // battleManeger �������I�Ɏ擾����
        battleManager = FindObjectOfType<battleManeger>();
        if (battleManager == null)
        {
            Debug.LogWarning("battleManager ���V�[�����Ɍ�����܂���ł���");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} ���\���ɂ��܂���");
        if (battleManager != null)
        {
            // Phase��ExecutePhase�ɕύX
            battleManager.ChangePhaseToExecute();
        }
        else
        {
            Debug.LogWarning("battleManager ���ݒ肳��Ă��܂���");
        }

    }
}
