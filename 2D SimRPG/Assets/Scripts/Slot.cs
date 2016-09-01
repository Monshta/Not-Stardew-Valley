using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour,IDropHandler {
    public int id;
    private Inventory inv;
    void Start()
    {
        inv = GameObject.Find("ItemDatabase").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(inv.Items[id].ID == -1)
        {
            inv.Items[droppedItem.slotID] = new Item();
            inv.Items[id] = droppedItem.item;
            droppedItem.slotID = id;
        }
        else if(droppedItem.slotID != id)
        {
            Transform trans = this.transform.GetChild(0);
            trans.GetComponent<ItemData>().slotID = droppedItem.slotID;
            trans.transform.SetParent(inv.slots[droppedItem.slotID].transform);
            trans.transform.position = inv.slots[droppedItem.slotID].transform.position;

            droppedItem.slotID = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.Items[droppedItem.slotID] = trans.GetComponent<ItemData>().item;
            inv.Items[id] = droppedItem.item;
        }
    }

}
