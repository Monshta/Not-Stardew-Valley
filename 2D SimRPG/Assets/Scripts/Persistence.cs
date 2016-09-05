using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class Persistence : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SaveAll()
    {
        saveInventory();
    }
    public void LoadAll()
    {
        loadInventory();
    }
    private void saveInventory()
    {
        GameObject InventoryPanel = GameObject.Find("ItemDatabase").GetComponent<Inventory>().InventoryPanel;
        InventoryPanel.SetActive(true);
        GameObject.Find("ItemDatabase").GetComponent<Inventory>().Save();
        InventoryPanel.SetActive(false);
        
    }
    private void loadInventory()
    {
        Inventory inv = GameObject.Find("ItemDatabase").GetComponent<Inventory>();
        string file = File.ReadAllText(Application.persistentDataPath + "/itemData.json");
        JsonData loadItem = JsonMapper.ToObject(file);
        for (int i = 0; i < loadItem.Count; i++)
            for (int j = 0; j < (int)loadItem[i]["amount"]; j++)
                inv.AddItemByID((int)loadItem[i]["ID"]);
    }
}
