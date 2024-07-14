using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWalker : Item, IPickupable
{
    public void OnPickup()
    {
        IBabyStateChangeable baby = ItemTargetManager.Instance.Baby as IBabyStateChangeable;

        if (baby != null)
        {
            baby.ChangeBabyState(BabyState.Walker, 5);
        }

        ScoreManager.Instance.AddScore(_onUseScore);
        SoundManager.Instance.PlaySe(SeName.GetBabyWalker);
    }

    public void StockToInventory(Inventory inventory)
    {
        inventory.onClickItemEffect += this.ApplyEffect;
    }

    public void ApplyEffect()
    {

    }
}
