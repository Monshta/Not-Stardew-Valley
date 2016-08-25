using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buildingStats : MonoBehaviour {
    int cost = 1;
    int revenue = 1;
    int maxWorkers = 2;
    int curWorkers = 0;
    int curCleanliness = 10;
    int maxCleanliness = 10;
    GameObject controller;
    public bool isUpgradeable;
    public bool isBuildable;

    // Use this for initialization
    void Start () {
        GameObject controller = GameObject.Find("Controller");
    }
	
	// Update is called once per frame
	void Update () {

	}
    //needs collider to work
    void OnMouseDown()
    {
        MainController.setSelectedObject(gameObject);
        MainController.SetDisplayText(GetCurrentStatString());
        if (isUpgradeable)
            GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Upgrade";
        if(isBuildable)
            GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Build";
    }


    string GetCurrentStatString()
    {
        if (isUpgradeable)
            return " This building costs " + cost.ToString() 
                + " to upgrade \n This building generates " + revenue 
                +"revenue \n This building is occupied by " +  curWorkers +"/"+ maxWorkers +
                "\n This building's cleanliness level is " + curCleanliness + "/" + maxCleanliness;
        else if (isBuildable)
            return "This building costs " + cost.ToString() + "  to build.";
        else
            return " ";
    }
    public void UpgradeBuilding()
    {
        if (GameObject.Find("HUD").GetComponent<HUDScript>().moneyDown(cost))
        {
            cost += 1;
            MainController.SetDisplayText(GetCurrentStatString());
        }
        else
            MainController.SetDisplayText("Not Enough funds");
    }
    public void Build()
    {
        isBuildable = false;
        isUpgradeable = true;
        GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Upgrade";
        MainController.SetDisplayText(GetCurrentStatString());
    }
}
