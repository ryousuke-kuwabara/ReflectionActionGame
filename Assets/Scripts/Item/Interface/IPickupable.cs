using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    void StockToInventory(Inventory inventory);
    void OnPickup();
}