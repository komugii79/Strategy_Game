
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectableText : Selectable
{
    public int commandIndex; // ���̃e�L�X�g���Ή�����R�}���h�̃C���f�b�N�X
    private battleManeger battleManager; // battleManager�ւ̎Q��

    protected override void Start()
    {
        base.Start();
        battleManager = FindObjectOfType<battleManeger>(); // battleManager���擾
        if (battleManager == null)
        {
            Debug.LogError("battleManeger��������܂���B�V�[���ɔz�u����Ă��邱�Ƃ��m�F���Ă��������B");
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);

        if (battleManager != null)
        {
            // �R�}���h�C���f�b�N�X��ݒ�
            battleManager.SelectCommand(commandIndex);
            Debug.Log($"�R�}���h {commandIndex} ���I������܂���: {gameObject.name}");

            // �t�F�[�Y��ύX
            battleManager.ChangePhaseToExecute();

            // �I���������m���Ɏ��s
            StartCoroutine(DeselectAfterFrame());
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name} �̑I������������܂���");
    }

    private IEnumerator DeselectAfterFrame()
    {
        // ���̃t���[���܂őҋ@
        yield return null;

        // �I������
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log("�I�����������s����܂���");
    }
}
