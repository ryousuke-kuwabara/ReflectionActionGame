using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMic : Item, IPickupable, IStockable
{
    public void OnPickup()
    {
        ScoreManager.Instance.AddScore(_onPickupScore);
        SoundManager.Instance.PlaySe(SeName.GetPickupableItem);
    }

    public void StockToInventory(Inventory inventory)
    {
        inventory.onClickItemEffect += this.ApplyEffect;
    }

    public void ApplyEffect()
    {
        IBabyStateChangeable baby = ItemTargetManager.Instance.Baby as IBabyStateChangeable;

        if (baby != null)
        {
            baby.ChangeBabyState(BabyState.Mic, 3);
        }

        ScoreManager.Instance.AddItemScore(_onUseScore);
    }
}
