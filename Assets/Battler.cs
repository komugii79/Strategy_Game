using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    public new string name;
    public int hp;

    //���s����R�}���h
    public CommandSO selectCommand;
    public Battler target;

    //�����Ă���R�}���h
    public CommandSO[] commands;

}
