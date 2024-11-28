using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public Slider hpSlider;        // HPバー
    public TextMeshProUGUI HPText; // HPの数値表示
    public int maxHP = 100;        // 最大HP
    public int currentHP;          // 現在のHP

    public int attackPower = 10;   // 攻撃力
    public int defensePower = 5;   // 防御力
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
        ATKText.text = $"{attackPower}";
        DEFText.text = $"{defensePower}";
    }
}
