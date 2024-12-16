
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class battleManeger : MonoBehaviour
{
    [SerializeField] private Battler player = default;
    [SerializeField] private Battler enemy = default;
    [SerializeField] private GameObject targetUI;
    [SerializeField] private GameObject targetEndUI;

    [SerializeField] private Slider playerHPSlider;
    [SerializeField] private Slider enemyHPSlider;
    [SerializeField] private Slider playerMPSlider;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI moneyText;

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
        if (GameManager.Instance != null)
        {
            player.hp = GameManager.Instance.hp;
            player.mp = GameManager.Instance.mp;
            player.attack = GameManager.Instance.attack;
            player.defense = GameManager.Instance.defense;
            player.money = GameManager.Instance.playerMoney;
        }

        UpdateUI();

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

        if (playerMPSlider != null)
        {
            playerMPSlider.maxValue = player.hp;
            playerMPSlider.value = player.hp;
            playerMPSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(player, value));
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
                    if(playerCommandIndex==0)
                    {
                        player.target = enemy;
                    }
                    else
                    {
                        player.target = player;
                    }
                  

                    enemy.selectCommand = enemy.commands[0];
                    enemy.target = player;

                    Debug.Log($"�I�����ꂽ�Z: {player.selectCommand.name}");
                    break;

                case Phase.ExecutePhase:
                    // �Z�̎��s
                    player.selectCommand.Execute(player, player.target);
                    if (playerHPSlider != null) playerHPSlider.value = player.hp;
                    if (enemyHPSlider != null) enemyHPSlider.value = enemy.hp;

                    UpdateUI();

                    // ���ʂ̔���
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                        break;
                    }

                    enemy.selectCommand.Execute(enemy, enemy.target);

                    if (playerHPSlider != null) playerHPSlider.value = player.hp;
                    if (enemyHPSlider != null) enemyHPSlider.value = enemy.hp;

                    UpdateUI();

                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                        break;
                    }


                    if (playerMPSlider != null) playerMPSlider.value = player.mp;

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
                    
                    break;

                case Phase.Result:
                    Debug.Log("�o�g���I��");
                    player.money = 100;
                    Debug.Log("����GET");

                    SavePlayerData();
                    Debug.Log("�f�[�^��ۑ�");

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

    void UpdateUI()
    {
        hpText.text = player.hp.ToString();
        mpText.text = player.mp.ToString();
        attackText.text = player.attack.ToString();
        defenseText.text = player.defense.ToString();
        moneyText.text = player.money.ToString();
    }

    void SavePlayerData()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.hp = player.hp;
            GameManager.Instance.mp = player.mp;
            GameManager.Instance.attack = player.attack;
            GameManager.Instance.defense = player.defense;
            GameManager.Instance.playerMoney = player.money;
        }
    }
}
