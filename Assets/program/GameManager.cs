using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hp = 100;          // HPの初期値
    public int mp = 100;          // MPの初期値
    public int attack = 10;       // ATKの初期値
    public int defense = 10;       // DEFの初期値
    public int playerMoney = 100; // 所持金

    // ステータスを表示するUI
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI attackText; 
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI moneyText; 

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
            case "MP":
                mp += amount;
                mp = Mathf.Clamp(mp, 0, 200);
                break;
            default:
                Debug.LogWarning($"未知のステータスタイプ:{type}");
                break;

        }
        UpdateUI();
    }
    public void UpdateMoney(int amount)
    {
        playerMoney += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        hpText.text = hp.ToString();
        mpText.text = mp.ToString();
        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        moneyText.text = playerMoney.ToString();
    }
}


