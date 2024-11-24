using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_battlescene : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
