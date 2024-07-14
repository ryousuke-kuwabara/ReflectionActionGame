using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryList inventoryList;

    [SerializeField] private BabyController baby;
    [SerializeField] private HandController hand;

    public Action onItemUse;


    private void Start()
    {
        baby.onItemCollision += this.OnItemPickup;
    }

    private void OnStackableItemPickup(IStockable stackable)
    {
        Inventory targetInventory = inventoryList.FirstEmptyInventory();
        stackable.StockToInventory(targetInventory);
    }

    private void OnItemPickup(Item item)
    {
        if (item is IPickupable && item is IStockable)
        {
            IStockable stockable = item as IStockable;

            Inventory inventoryToStock = this.inventoryList.FirstEmptyInventory();
            stockable.StockToInventory(inventoryToStock);

            inventoryToStock.SetItemIcon(item.GetSprite());
        }

        IPickupable pickupable = item as IPickupable;
        pickupable.OnPickup();
    }
}