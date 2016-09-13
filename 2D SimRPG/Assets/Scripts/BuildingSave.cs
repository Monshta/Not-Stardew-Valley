using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
public class BuildingSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveStand()
    {
        List<string> strList = new List<string>();
        foreach(GameObject building in GameObject.FindGameObjectsWithTag("Building"))
        {
            if(building.name == "Stand(Clone)")
            {
                building.GetComponent<buildingStats>().NewDay();
                BuildingData buildingData = new BuildingData();
                buildingStats buildingstat = building.GetComponent<buildingStats>();
                buildingData.cost = buildingstat.cost;
                buildingData.revenue = buildingstat.revenue;
                buildingData.maxWorkers = buildingstat.maxWorkers;
                buildingData.curWorkers = buildingstat.curWorkers;
                buildingData.curCleanliness = buildingstat.curCleanliness;
                buildingData.maxCleanliness = buildingstat.maxCleanliness;
                buildingData.moneyStored = buildingstat.moneyStored;
                buildingData.posx = (int)building.transform.position.x;
                buildingData.posy = (int)building.transform.position.y;
                strList.Add(JsonMapper.ToJson(buildingData).ToString());
            }
        }
        string finalString = string.Join(",", strList.ToArray());
        File.WriteAllText(Application.persistentDataPath + "/standData.json", "[" + finalString + "]");
    }
}

class BuildingData{
    public int cost;
    public int revenue;
    public int maxWorkers;
    public int curWorkers;
    public int curCleanliness;
    public int maxCleanliness;
    public int moneyStored;
    public int posx;
    public int posy;
}