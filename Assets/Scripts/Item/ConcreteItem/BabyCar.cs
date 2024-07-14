using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCar : Item, IPickupable
{
    public void OnPickup()
    {
        IBabyStateChangeable baby = ItemTargetManager.Instance.Baby as IBabyStateChangeable;

        if (baby != null)
        {
            baby.ChangeBabyState(BabyState.Car, 5);
        }

        ScoreManager.Instance.AddScore(_onPickupScore);
    }

    public void StockToInventory(Inventory inventory)
    {
        inventory.onClickItemEffect += this.ApplyEffect;
    }

    public void ApplyEffect()
    {

    }
}
