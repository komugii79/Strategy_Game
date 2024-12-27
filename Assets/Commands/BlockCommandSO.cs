using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class BlockCommandplayer : CommandSO
{
    [SerializeField] int block;

    public override void Execute(Battler user, Battler target)
    {
        user.block = 1;
        Debug.LogWarning($"{user}‚ÌƒuƒƒbƒN‚Í{user.block}");
    }
}
