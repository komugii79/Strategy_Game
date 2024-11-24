using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_buyscene : MonoBehaviour
{
   public void change_button()
   {
        SceneManager.LoadScene("BuyScene");
   }
}
