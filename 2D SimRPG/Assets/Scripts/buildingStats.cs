using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buildingStats : MonoBehaviour {
    float cost = 0.0f;
    int inhabitants = 0;
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
            return "This building costs: " + cost.ToString() + " to upgrade and has " + inhabitants.ToString() + " inhabitants";
        else if (isBuildable)
            return "This building costs " + cost.ToString() + "  to build.";
        else
            return " ";
    }
    public void UpgradeBuilding()
    {
        cost += 1;
        MainController.SetDisplayText(GetCurrentStatString());
    }
    public void Build()
    {
        isBuildable = false;
        isUpgradeable = true;
        GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Upgrade";
        MainController.SetDisplayText(GetCurrentStatString());
    }
}
