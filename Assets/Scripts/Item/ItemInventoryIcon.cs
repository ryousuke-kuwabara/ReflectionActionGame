using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryIcon : MonoBehaviour, IIcon
{
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void SetIcon(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }

    public void RemoveIcon()
    {
        this.spriteRenderer.sprite = null;
    }
}
