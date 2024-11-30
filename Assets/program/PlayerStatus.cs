using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public Slider hpSlider;        // HP�o�[
    public TextMeshProUGUI HPText; // HP�̐��l�\��
    public int maxHP = 300;        // �ő�HP
    public int currentHP = 100;          // ���݂�HP
    public TextMeshProUGUI MPText;
    public int Mp = 100;

    public int attackPower = 10;   // �U����
    public int defensePower = 10;   // �h���
    public TextMeshProUGUI ATKText; // �U���͕\��
    public TextMeshProUGUI DEFText; // �h��͕\��

    void Start()
    {
        currentHP = maxHP;
        UpdateStatsUI();
    }

    // HP�𑝉������郁�\�b�h
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

    // �U���͂𑝉������郁�\�b�h
    public void AddAttack(int amount)
    {
        attackPower += amount;
        UpdateStatsUI();
    }

    // �h��͂𑝉������郁�\�b�h
    public void AddDefense(int amount)
    {
        defensePower += amount;
        UpdateStatsUI();
    }

    // �X�e�[�^�XUI���X�V���郁�\�b�h
    void UpdateStatsUI()
    {
        hpSlider.value = (float)currentHP / maxHP;
        HPText.text = $"{currentHP}/{maxHP}";
        MPText.text = $"{Mp}";
        ATKText.text = $"{attackPower}";
        DEFText.text = $"{defensePower}";
    }
}
