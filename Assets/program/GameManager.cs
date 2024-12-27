using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hp = 100;          // HPの初期値
    public int mp = 100;          // MPの初期値
    public int attack = 10;       // ATKの初期値
    public int defense = 10;       // DEFの初期値
    public int playerMoney = 100; // 所持金

    public int lap = 1;

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
            DontDestroyOnLoad(gameObject);
            AssignUIElements();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignUIElements();
        UpdateUI();
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

    private void AssignUIElements()
    {
        hpText = GameObject.Find("HPText")?.GetComponent<TextMeshProUGUI>();
        mpText = GameObject.Find("MPText")?.GetComponent<TextMeshProUGUI>();
        attackText = GameObject.Find("ATKText")?.GetComponent<TextMeshProUGUI>();
        defenseText = GameObject.Find("DEFText ")?.GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("Money")?.GetComponent<TextMeshProUGUI>();
    }

    void UpdateUI()
    {
        if (hpText != null) hpText.text = hp.ToString();
        if (mpText != null) mpText.text = mp.ToString();
        if (attackText != null) attackText.text = attack.ToString();
        if (defenseText != null) defenseText.text = defense.ToString();
        if (moneyText != null) moneyText.text = playerMoney.ToString();
    }
}


