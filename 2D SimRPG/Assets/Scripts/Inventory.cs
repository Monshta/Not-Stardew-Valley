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
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(SlotPanel.transform);
        }
        AddItemByID(0);
        AddItemByTitle("Wood");
        AddItemByTitle("Wood");
        AddItemByTitle("Wood");
        AddItemByID(2);
        MainController mainController = GameObject.Find("Controller").GetComponent<MainController>();
        InventoryPanel.SetActive(false);
    }
    bool IsItemInInventory(Item item)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == item.ID)
                return true;
        }
        return false;
    }
    public void AddItemByID(int id)
    {
        Item itemToAdd = database.SearchItemByID(id);
        if (itemToAdd.Stackable && IsItemInInventory(itemToAdd))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == -1)
                {
                    Items[i] = itemToAdd;
                    GameObject itemObject = Instantiate(InventoryItem);
                    itemObject.GetComponent<ItemData>().item = itemToAdd;
                    itemObject.GetComponent<ItemData>().slotID = i;
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

    public void AddItemByTitle(string title)
    {
        Item itemToAdd = database.SearchItemByTitle(title);
        if (itemToAdd.Stackable && IsItemInInventory(itemToAdd))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Title == title)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == -1)
                {
                    Items[i] = itemToAdd;
                    GameObject itemObject = Instantiate(InventoryItem);
                    itemObject.GetComponent<ItemData>().item = itemToAdd;
                    itemObject.GetComponent<ItemData>().slotID = i;
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
}
