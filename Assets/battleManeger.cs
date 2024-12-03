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
                    player.target = player;
                    enemy.selectCommand = enemy.commands[0];
                    enemy.target = player;

                    Debug.Log($"選択された技: {player.selectCommand.name}");
                    break;

                case Phase.ExecutePhase:
                    // 技の実行
                    player.selectCommand.Execute(player, player.target);
                    enemy.selectCommand.Execute(enemy, enemy.target);

                    if (playerHPSlider != null) playerHPSlider.value = player.hp;
                    if (enemyHPSlider != null) enemyHPSlider.value = enemy.hp;

                    // 結果の判定
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
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
                    }
                    break;

                case Phase.Result:
                    Debug.Log("バトル終了");
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
}
