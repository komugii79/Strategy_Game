
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
        //Debug.Log($"{user.name}�̍U��:{target.name}��{at}�̃_���[�W:�c���HP{target.hp}");
    }
}
