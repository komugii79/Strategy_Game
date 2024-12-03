using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public Slider hpSlider;        // HPバー
    public TextMeshProUGUI HPText; // HPの数値表示
    public int maxHP = 300;        // 最大HP
    public int currentHP = 100;          // 現在のHP
    public TextMeshProUGUI MPText;
    public int Mp = 100;

    public int attackPower = 10;   // 攻撃力
    public int defensePower = 10;   // 防御力
    public TextMeshProUGUI ATKText; // 攻撃力表示
    public TextMeshProUGUI DEFText; // 防御力表示

    void Start()
    {
        currentHP = maxHP;
        UpdateStatsUI();
    }

    // HPを増加させるメソッド
    public void AddHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateStatsUI();
    }
    public void AddMP(int amount)
    {
        Mp += amount;
        UpdateStatsUI();
    }

    // 攻撃力を増加させるメソッド
    public void AddAttack(int amount)
    {
        attackPower += amount;
        UpdateStatsUI();
    }

    // 防御力を増加させるメソッド
    public void AddDefense(int amount)
    {
        defensePower += amount;
        UpdateStatsUI();
    }

    // ステータスUIを更新するメソッド
    void UpdateStatsUI()
    {
        hpSlider.value = (float)currentHP / maxHP;
        HPText.text = $"{currentHP}/{maxHP}";
        MPText.text = $"{Mp}";
        ATKText.text = $"{attackPower}";
        DEFText.text = $"{defensePower}";
    }
}
