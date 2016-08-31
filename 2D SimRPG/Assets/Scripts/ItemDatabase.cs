using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData ItemData;

    void Start()
    {
        ItemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();    }
	
    void ConstructItemDatabase()
    {
        for(int i= 0; i < ItemData.Count; i++)
        {
            database.Add(new Item((int)ItemData[i]["id"], ItemData[i]["title"].ToString(), ItemData[i]["type"].ToString(),
                (bool)ItemData[i]["stackable"],(bool)ItemData[i]["equipable"], (int)ItemData[i]["stats"]["attack"], 
                (int)ItemData[i]["stats"]["defense"], (bool)ItemData[i]["consumable"], ItemData[i]["description"].ToString(), 
                (int)ItemData[i]["buyValue"],(int)ItemData[i]["sellValue"],ItemData[i]["slug"].ToString()));
        }
    }

    public Item SearchItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    public Item SearchItemByTitle(string title)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].Title == title)
                return database[i];
        }
        return null;
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public bool Stackable { get; set; }
    public bool Equipable { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool Consumable { get; set; }
    public string Description { get; set; }
    public int BuyValue { get; set; }
    public int SellValue { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    public Item(int id, string title, string type, bool stackable, bool equipable, int attack, int defense, bool consumable, string description, int buyValue, int sellValue, string slug )
    {
        this.ID = id;
        this.Title = title;
        this.Type = type;
        this.Stackable = stackable;
        this.Equipable = equipable;
        this.Attack = attack;
        this.Defense = Defense;
        this.Consumable = consumable;
        this.Description = description;
        this.BuyValue = buyValue;
        this.SellValue = sellValue;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("ItemSlugs/" + slug);
    }
    public Item()
    {
        this.ID = -1;
    }
}
