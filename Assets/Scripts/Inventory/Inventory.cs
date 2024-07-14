using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemInventoryIcon icon;

    private EventTrigger eventTrigger;
    public Action onClickItemEffect;

    private void Start()
    {
        this.AddClickEventToUseItem();
    }

    private void AddClickEventToUseItem()
    {
        this.eventTrigger = this.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry newEntry = new EventTrigger.Entry();

        newEntry.eventID = EventTriggerType.PointerDown;
        newEntry.callback.AddListener((x) => this.UseItem());

        this.eventTrigger.triggers.Add(newEntry);
    }

    private void UseItem()
    {
        if (!ItemTargetManager.Instance.Baby.IsCrawling()) { return; }

        this.onClickItemEffect?.Invoke();
        this.onClickItemEffect = null;

        this.icon.RemoveIcon();
    }

    public void SetItemIcon(Sprite icon)
    {
        this.icon.SetIcon(icon);
    }

    public bool IsEmpty()
    {
        return (this.onClickItemEffect == null);
    }

    public enum InventoryStatus
    {
        Empty,
        Full,
    }
}