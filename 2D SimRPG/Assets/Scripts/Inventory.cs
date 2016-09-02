using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    GameObject InventoryPanel;
    GameObject SlotPanel;
    GameObject WieldingPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public GameObject WieldedHighlight;
    GameObject highlightedObj;
    ItemDatabase database;
    int slotAmount;
    int wieldSlotAmount;
    public List<Item> Items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 26;
        wieldSlotAmount = 8;
        InventoryPanel = GameObject.Find("InventoryPanel");
        SlotPanel = InventoryPanel.transform.FindChild("SlotPanel").gameObject;
        WieldingPanel = GameObject.Find("WieldingPanel");
        for (int i = 0; i < wieldSlotAmount; i++)
        {
            Items.Add(new Item());
            slots.Add(Instantiate(InventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(WieldingPanel.transform);
        }
        for (int i = wieldSlotAmount; i < slotAmount; i++)
        {
            Items.Add(new Item());
            slots.Add(Instantiate(InventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(SlotPanel.transform);
        }
        highlightedObj = Instantiate(WieldedHighlight);
        highlightedObj.transform.SetParent(slots[0].transform);
        AddItemByID(0);
        AddItemByTitle("Wood");
        AddItemByTitle("Wood");
        AddItemByTitle("Wood");
        AddItemByID(2);
        MainController mainController = GameObject.Find("Controller").GetComponent<MainController>();
        InventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            changeWielded(0);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            changeWielded(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            changeWielded(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            changeWielded(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            changeWielded(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            changeWielded(5);
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            changeWielded(6);
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            changeWielded(7);
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            int place = highlightedObj.transform.parent.GetComponent<Slot>().id;
            if ( place == 7)
                changeWielded(0);
            else
                changeWielded(place + 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int place = highlightedObj.transform.parent.GetComponent<Slot>().id;
            if (place == 0)
                changeWielded(7);
            else
                changeWielded(place - 1);
        }
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
            addToInventorySlot(itemToAdd);
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
            addToInventorySlot(itemToAdd);
        }
    }

    private void addToInventorySlot(Item itemToAdd)
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
                break;
            }
        }
    }
    private void changeWielded(int place)
    {
        highlightedObj.transform.SetParent(slots[place].transform);
        highlightedObj.transform.localPosition = new Vector2(0, -30);
        highlightedObj.transform.SetAsFirstSibling();
        MainController.wieldedItem = getWieldedItem();
    }

    public Item getWieldedItem()
    {
        if (highlightedObj.transform.parent.GetChild(1).gameObject.GetComponent<ItemData>().item.ID != -1)
            return highlightedObj.transform.parent.GetChild(1).gameObject.GetComponent<ItemData>().item;
        return null;
    }
}
