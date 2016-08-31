using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    GameObject InventoryPanel;
    GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    ItemDatabase database;
    int slotAmount;
    public List<Item> Items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 18;
        InventoryPanel = GameObject.Find("InventoryPanel");
        SlotPanel = InventoryPanel.transform.FindChild("SlotPanel").gameObject;
        for(int i = 0; i < 18; i++)
        {
            Items.Add(new Item());
            slots.Add(Instantiate(InventorySlot));
            slots[i].transform.SetParent(SlotPanel.transform);
        }
        AddItemByID(0);
        AddItemByTitle("Wood");
    }
    public void AddItemByID(int id)
    {
        Item itemToAdd = database.SearchItemByID(id);
        for(int i = 0; i < Items.Count; i++)
        {
            if(Items[i].ID == -1)
            {
                Items[i] = itemToAdd;
                GameObject itemObject = Instantiate(InventoryItem);
                itemObject.transform.SetParent(slots[i].transform);
                itemObject.transform.position = Vector2.zero;
                itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObject.name = itemToAdd.Title;
                slots[i].name = "Slot" + itemToAdd.Title;
                break;
            }
        }
    }

    public void AddItemByTitle(string title)
    {
        Item itemToAdd = database.SearchItemByTitle(title);
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == -1)
            {
                Items[i] = itemToAdd;
                GameObject itemObject = Instantiate(InventoryItem);
                itemObject.transform.SetParent(slots[i].transform);
                itemObject.transform.position = Vector2.zero;
                itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObject.name = itemToAdd.Title;
                slots[i].name = "Slot" + itemToAdd.Title;
                break;
            }
        }
    }
}
