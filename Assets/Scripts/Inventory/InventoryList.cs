using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    [SerializeField] private Inventory[] inventoryList;

    public void AddItem(Item item, IPickupable pickup, IUseable useable)
    {
        Inventory firstEmptyInventory = this.FirstEmptyInventory();

        if (firstEmptyInventory != null)
        {
            // firstEmptyInventory.SetItem(item, useable);
        } else
        {
            // inventoryList[0].SetItem(item, useable);
        }
    }

    public Inventory FirstEmptyInventory()
    {
        Inventory emptyInventory = null;

        foreach (Inventory inventory in this.inventoryList)
        {
            if (inventory.IsEmpty())
            {
                emptyInventory = inventory;
                break;
            }
        }

        if (emptyInventory == null)
        {
            emptyInventory = this.inventoryList[1];
        }

        return emptyInventory;
    }
}
