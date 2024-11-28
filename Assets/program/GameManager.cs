using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hp = 100;         // HP�̏����l
    public int attack = 10;      // ATK�̏����l
    public int defense = 5;      // DEF�̏����l

    // �X�e�[�^�X��\������UI
    public TextMeshProUGUI hpText;         
    public TextMeshProUGUI attackText; 
    public TextMeshProUGUI defenseText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateStatus(string type, int amount)
    {
        switch (type)
        {
            case "HP":
                hp += amount;
                hp = Mathf.Clamp(hp, 0, 300);
                break;

            case "ATK":
                attack += amount;
                break;
            case "DEF":
                defense += amount;
                break;
            default:
                Debug.LogWarning($"���m�̃X�e�[�^�X�^�C�v:{type}");
                break;

        }
        UpdateUI();
    }

    void UpdateUI()
    {
        hpText.text = hp.ToString();
        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
    }
}


