using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class battleManeger : MonoBehaviour
{
    [SerializeField] private Battler player = default;
    [SerializeField] private Battler enemy = default;
    [SerializeField] private GameObject targetUI;
    [SerializeField] private GameObject targetEndUI;

    [SerializeField] private Slider playerHPSlider;
    [SerializeField] private Slider enemyHPSlider;

    private int playerCommandIndex = 0; // �Z�̃C���f�b�N�X��ێ�

    private enum Phase
    {
        StartPhase,
        ChooseCommandPhase,
        ExecutePhase,
        Result,
        End,
    }

    private Phase phase;

    void Start()
    {
        phase = Phase.StartPhase;

        if (playerHPSlider != null)
        {
            playerHPSlider.maxValue = player.hp;
            playerHPSlider.value = player.hp;
            playerHPSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(player, value));
        }

        if (enemyHPSlider != null)
        {
            enemyHPSlider.maxValue = enemy.hp;
            enemyHPSlider.value = enemy.hp;
            enemyHPSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(enemy, value));
        }

        StartCoroutine(Battle());
    }

    private void OnSliderValueChanged(Battler battler, float value)
    {
        battler.hp = Mathf.RoundToInt(value); // �X���C�_�[�l��hp�ɔ��f
        Debug.Log($"{battler.name} ��HP�� {battler.hp} �ɕύX����܂���");
    }

    // �t�F�[�Y�� ExecutePhase �ɕύX
    public void ChangePhaseToExecute()
    {
        if (phase == Phase.ChooseCommandPhase)
        {
            phase = Phase.ExecutePhase;
            Debug.Log("�t�F�[�Y�� ExecutePhase �ɕύX����܂���");
        }
        else
        {
            Debug.LogWarning("ChangePhaseToExecute ���Ăяo���܂������A���݂̃t�F�[�Y�� ChooseCommandPhase �ł͂���܂���");
        }
    }

    // �{�^���̃N���b�N�ŋZ��I��
    public void SelectCommand(int commandIndex)
    {
        playerCommandIndex = commandIndex;
        Debug.Log($"�Z���I������܂���: �R�}���h�C���f�b�N�X {commandIndex}");
    }

    private IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;

            Debug.Log($"���݂̃t�F�[�Y: {phase}");

            switch (phase)
            {
                case Phase.StartPhase:
                    phase = Phase.ChooseCommandPhase;
                    break;

                case Phase.ChooseCommandPhase:
                    // �Z���I�������܂őҋ@
                    yield return new WaitUntil(() => phase == Phase.ExecutePhase);

                    // �I�����ꂽ�Z��ݒ�
                    player.selectCommand = player.commands[playerCommandIndex];
                    player.target = player;
                    enemy.selectCommand = enemy.commands[0];
                    enemy.target = player;

                    Debug.Log($"�I�����ꂽ�Z: {player.selectCommand.name}");
                    break;

                case Phase.ExecutePhase:
                    // �Z�̎��s
                    player.selectCommand.Execute(player, player.target);
                    enemy.selectCommand.Execute(enemy, enemy.target);

                    if (playerHPSlider != null) playerHPSlider.value = player.hp;
                    if (enemyHPSlider != null) enemyHPSlider.value = enemy.hp;

                    // ���ʂ̔���
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
                        if (targetUI != null)
                        {
                            targetUI.SetActive(true);
                            Debug.Log($"{targetUI.name} ��\�����܂���");
                        }
                        else
                        {
                            Debug.LogWarning("targetUI ���ݒ肳��Ă��܂���");
                        }

                        phase = Phase.ChooseCommandPhase;
                    }
                    break;

                case Phase.Result:
                    Debug.Log("�o�g���I��");
                    phase = Phase.End;
                    break;

                case Phase.End:
                    

                    break;
            }
        }

        if (targetUI != null)
        {
            targetUI.SetActive(false);
            Debug.Log($"{targetUI.name} ��\�����܂���");
        }

        if (targetEndUI != null)
        {
            targetEndUI.SetActive(true);
            Debug.Log($"{targetEndUI.name} ��\�����܂���");
        }
        else
        {
            Debug.LogWarning("targetEndUI ���ݒ肳��Ă��܂���");
        }
    }
}
