
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

    private int playerCommandIndex = 0; // 技のインデックスを保持

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
        battler.hp = Mathf.RoundToInt(value); // スライダー値をhpに反映
        Debug.Log($"{battler.name} のHPが {battler.hp} に変更されました");
    }

    // フェーズを ExecutePhase に変更
    public void ChangePhaseToExecute()
    {
        if (phase == Phase.ChooseCommandPhase)
        {
            phase = Phase.ExecutePhase;
            Debug.Log("フェーズが ExecutePhase に変更されました");
        }
        else
        {
            Debug.LogWarning("ChangePhaseToExecute を呼び出しましたが、現在のフェーズが ChooseCommandPhase ではありません");
        }
    }

    // ボタンのクリックで技を選択
    public void SelectCommand(int commandIndex)
    {
        playerCommandIndex = commandIndex;
        Debug.Log($"技が選択されました: コマンドインデックス {commandIndex}");
    }

    private IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;

            Debug.Log($"現在のフェーズ: {phase}");

            switch (phase)
            {
                case Phase.StartPhase:
                    phase = Phase.ChooseCommandPhase;
                    break;

                case Phase.ChooseCommandPhase:
                    // 技が選択されるまで待機
                    yield return new WaitUntil(() => phase == Phase.ExecutePhase);

                    // 選択された技を設定
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

                    Debug.Log($"選択された技: {player.selectCommand.name}");
                    break;

                case Phase.ExecutePhase:
                    // 技の実行
                    player.selectCommand.Execute(player, player.target);
                    if (playerHPSlider != null) playerHPSlider.value = player.hp;
                    if (enemyHPSlider != null) enemyHPSlider.value = enemy.hp;

                    UpdateUI();

                    // 結果の判定
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
                        Debug.Log($"{targetUI.name} を表示しました");
                    }
                    else
                    {
                        Debug.LogWarning("targetUI が設定されていません");
                    }
                    
                    phase = Phase.ChooseCommandPhase;
                    
                    break;

                case Phase.Result:
                    Debug.Log("バトル終了");
                    player.money = 100;
                    Debug.Log("お金GET");

                    SavePlayerData();
                    Debug.Log("データを保存");

                    phase = Phase.End;
                    break;

                case Phase.End:

                    break;
            }
        }

        if (targetUI != null)
        {
            targetUI.SetActive(false);
            Debug.Log($"{targetUI.name} を表示しました");
        }

        if (targetEndUI != null)
        {
            targetEndUI.SetActive(true);
            Debug.Log($"{targetEndUI.name} を表示しました");
        }
        else
        {
            Debug.LogWarning("targetEndUI が設定されていません");
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
