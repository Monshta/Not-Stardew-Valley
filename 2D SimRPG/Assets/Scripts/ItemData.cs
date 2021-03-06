﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int amount = 1;
    public int slotID;

    private Transform originalParent;
    private Inventory inv;
    private Vector2 offset;
    private Tooltip tooltip;

    void Start()
    {
        inv = GameObject.Find("ItemDatabase").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            offset = eventData.position = new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inv.slots[slotID].transform);
        this.transform.position = inv.slots[slotID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        inv.highlightedObj.transform.SetAsLastSibling();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(ConstructDataString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    public string ConstructDataString()
    {
        string data = "<b>" + item.Title + "</b>\n<color=#0473f0>" + item.Type + "</color>\n\n" + item.Description;
        if (item.Equipable)
        {
            data += "\n\nAttack: " + item.Attack + " Defense: " + item.Defense;
        }
        return data;
    }
}
