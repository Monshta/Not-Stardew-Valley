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
        ConstructItemDatabase();
    }
	
    void ConstructItemDatabase()
    {
        for(int i= 0; i < ItemData.Count; i++)
        {
            database.Add(new Item((int)ItemData[i]["id"], ItemData[i]["title"].ToString(), (int)ItemData[i]["value"]));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }

    public Item(int id, string title, int value)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
    }
}
