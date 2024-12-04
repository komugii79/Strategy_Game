
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CommandSO : ScriptableObject
{
    public new string name;
    public virtual void Execute(Battler user, Battler target)
    {
        //target.hp -= at;
        //Debug.Log($"{user.name}の攻撃:{target.name}に{at}のダメージ:残りのHP{target.hp}");
    }
}
