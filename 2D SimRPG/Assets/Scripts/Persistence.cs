using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class Persistence : MonoBehaviour {
    public GameObject stand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SaveAll()
    {
        saveInventory();
        GameObject.Find("HUD").GetComponent<HUDScript>().Save();
        GameObject.Find("Bed").GetComponent<BuildingSave>().SaveStand();
    }
    public void LoadAll()
    {
        loadInventory();
        loadStand();
        GameObject.Find("HUD").GetComponent<HUDScript>().Load();
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
    
    private void loadStand()
    {
        string file = File.ReadAllText(Application.persistentDataPath + "/standData.json");
        JsonData loadStand = JsonMapper.ToObject(file);
        for(int i = 0; i < loadStand.Count; i++)
        {
            transform.position = new Vector2((float)(int)loadStand[i]["posx"], (float)(int)loadStand[i]["posy"]);
            GameObject objStand = (GameObject)Instantiate(stand, transform.position,Quaternion.identity);
            buildingStats buildingstat = objStand.GetComponent<buildingStats>();
            buildingstat.cost = (int)loadStand[i]["cost"];
            buildingstat.revenue = (int)loadStand[i]["revenue"];
            buildingstat.maxWorkers = (int)loadStand[i]["maxWorkers"];
            buildingstat.curWorkers = (int)loadStand[i]["curWorkers"];
            buildingstat.maxCleanliness = (int)loadStand[i]["maxCleanliness"];
            buildingstat.curCleanliness = (int)loadStand[i]["curCleanliness"]; ;
            buildingstat.moneyStored = (int)loadStand[i]["moneyStored"];
        }
    }
}
