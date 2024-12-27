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
    [SerializeField] private GameObject targetBattleLog;

    [SerializeField] private Slider playerHPSlider;
    [SerializeField] private Slider enemyHPSlider;
    [SerializeField] private Slider playerMPSlider;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI moneyText;

    [SerializeField] private TextMeshProUGUI battleLogText;
    //private string battleLog = ""; // ���O�̓��e��ێ�

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
            player.block = 0;
            enemy.hp = enemy.hp * GameManager.Instance.lap;
            enemy.attack = enemy.attack * GameManager.Instance.lap;
        }

        UpdateUI();

        phase = Phase.StartPhase;

        SetupSliders();

        StartCoroutine(Battle());
    }

    private void SetupSliders()
    {
        if (playerHPSlider != null)
        {
            playerHPSlider.maxValue = player.hp;
            playerHPSlider.value = player.hp;
        }

        if (enemyHPSlider != null)
        {
            enemyHPSlider.maxValue = enemy.hp;
            enemyHPSlider.value = enemy.hp;
        }

        if (playerMPSlider != null)
        {
            playerMPSlider.maxValue = player.mp;
            playerMPSlider.value = player.mp;
        }
    }

    public void ChangePhaseToExecute()
    {
        if (phase == Phase.ChooseCommandPhase)
        {
            phase = Phase.ExecutePhase;
        }
        else
        {
            Debug.LogWarning("�t�F�[�Y�ύX���s: ���݂̃t�F�[�Y�� ChooseCommandPhase �ł͂���܂���");
        }
    }

    public void SelectCommand(int commandIndex)
    {
        playerCommandIndex = commandIndex;
    }

    private IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;

            switch (phase)
            {
                case Phase.StartPhase:
                    phase = Phase.ChooseCommandPhase;
                    break;

                case Phase.ChooseCommandPhase:
                    yield return new WaitUntil(() => phase == Phase.ExecutePhase);
                    AssignCommands();
                    break;

                case Phase.ExecutePhase:
                    yield return StartCoroutine(ExecuteCommandsWithDelay());
                    UpdateUI(); // UI��K���X�V����
                    CheckBattleResult();
                    break;

                case Phase.Result:
                    EndBattle();
                    break;

                case Phase.End:
                    break;
            }
        }
    }

    private void AssignCommands()
    {
        player.selectCommand = player.commands[playerCommandIndex];
        player.target = playerCommandIndex == 1 ? player : enemy;

        enemy.selectCommand = enemy.commands[0];
        enemy.target = player;
    }

    private void EndBattle()
    {
        player.money += 100; // ���̕�V
        player.hp = 100;
        SavePlayerData();
        phase = Phase.End;

        targetUI?.SetActive(false);
        targetEndUI?.SetActive(true);
    }

    void UpdateUI()
    {
        if (hpText != null) hpText.text = player.hp.ToString();
        if (mpText != null) mpText.text = player.mp.ToString();
        if (attackText != null) attackText.text = player.attack.ToString();
        if (defenseText != null) defenseText.text = player.defense.ToString();
        if (moneyText != null) moneyText.text = player.money.ToString();

        UpdateSliders();
    }

    void UpdateSliders()
    {
        if (playerHPSlider != null) playerHPSlider.value = Mathf.Clamp(player.hp, 0, playerHPSlider.maxValue);
        if (enemyHPSlider != null) enemyHPSlider.value = Mathf.Clamp(enemy.hp, 0, enemyHPSlider.maxValue);
        if (playerMPSlider != null) playerMPSlider.value = Mathf.Clamp(player.mp, 0, playerMPSlider.maxValue);
    }

    private IEnumerator ExecuteCommandsWithDelay()
    {
        // �v���C���[�̍U�������s
        player.selectCommand.Execute(player, player.target);
        UpdateSliders(); // �X���C�_�[�̒l���X�V

        if (enemy.block == 1)
        {
            enemy.block = 0;
        }

        // �������Ԃ��󂯂�
        yield return new WaitForSeconds(1f); // 1�b�Ԃ̒x��

        // �G�̍U�������s�i�v���C���[���܂��������Ă���ꍇ�j
        if (player.hp > 0 && enemy.hp > 0)
        {
            enemy.selectCommand.Execute(enemy, enemy.target);
            UpdateSliders(); // �X���C�_�[�̒l���X�V
        }
        
        if (player.block == 1)
        {
            player.block = 0;
        }
    }

    private void CheckBattleResult()
    {
        if (player.hp <= 0 || enemy.hp <= 0)
        {
            phase = Phase.Result;
        }
        else
        {
            phase = Phase.ChooseCommandPhase;
        }
    }


    public void UpdateBattleLog(string message)
    {
        if (targetBattleLog != null)
        {
            targetBattleLog.SetActive(false); // ���O��\��
        }

        if (battleLogText != null)
        {
            battleLogText.text = message; // ���O���X�V
        }

        if (targetBattleLog != null)
        {
            targetBattleLog.SetActive(true); // ���O��\��
        }
        StartCoroutine(HideBattleLogAfterDelay(1f)); // ��莞�Ԍ�Ƀ��O���\���i3�b��j
    }

    private IEnumerator HideBattleLogAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �w�莞�ԑҋ@

        if (targetBattleLog != null)
        {
            targetBattleLog.SetActive(false); // ���O���\��
        }

        if (battleLogText != null)
        {
            battleLogText.text = ""; // �e�L�X�g���e���N���A
        }
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
            GameManager.Instance.lap = GameManager.Instance.lap + 1;
        }
    }
}
