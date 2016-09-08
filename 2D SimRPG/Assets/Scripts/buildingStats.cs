using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class buildingStats : MonoBehaviour
{
    int cost = 1;
    int revenue = 1;
    int maxWorkers = 2;
    int curWorkers = 0;
    int curCleanliness = 0;
    int maxCleanliness = 10;
    int moneyStored = 100;
    GameObject controller;
    GameObject upgrateBtn;
    Tooltip tooltip;
    public bool isUpgradeable;
    public bool isBuildable;

    Text BldCost, BldMoneyStored, BldOccupancy, BldRenevue, BldCleanliness;

    // Use this for initialization
    void Start () {
        GameObject controller = GameObject.Find("Controller");
        upgrateBtn = GameObject.Find("UpgradeBtn");
        upgrateBtn.SetActive(false);
        tooltip = GameObject.Find("ItemDatabase").GetComponent<Tooltip>();
        BldCost = GameObject.Find("BldCost").GetComponent<Text>();
        BldRenevue = GameObject.Find("BldRevenue").GetComponent<Text>(); ;
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void OnMouseOver()
    {
        if(Time.timeScale > 0.0f)
            tooltip.Activate(ConstructDataString());
    }

    public void OnMouseExit()
    {
        tooltip.Deactivate();
    }
    //needs collider to work
    void OnMouseDown()
    {
        MainController.setSelectedObject(gameObject);
        SetCurrentStatString();
        if (isUpgradeable)
            GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Upgrade";
        if(isBuildable)
            GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Build";
    }


    void SetCurrentStatString()
    {
        if (isUpgradeable)
        {
            MainController.SetDisplayText("A very nice " + gameObject.name + "\n Costs " + cost +" to upgrade");
            upgrateBtn.SetActive(true);
        }
        else if (isBuildable)
            MainController.SetDisplayText("Looks like something was built here before");
        else
            MainController.SetDisplayText(" ");
    }
    public void UpgradeBuilding()
    {
        if (GameObject.Find("HUD").GetComponent<HUDScript>().moneyDown(cost))
        {
            cost += 1;
            SetCurrentStatString();
        }
        else
            MainController.SetDisplayText("Not Enough funds");
    }
    public void Build()
    {
        isBuildable = false;
        isUpgradeable = true;
        GameObject.Find("UpgradeTxt").GetComponent<Text>().text = "Upgrade";
        SetCurrentStatString();
    }
    public void CollectMoneyStored()
    {
        GameObject.Find("HUD").GetComponent<HUDScript>().moneyUp(moneyStored);
        moneyStored = 0;
    }
    public void Repair()
    {
        if(curCleanliness < maxCleanliness)
            curCleanliness += 1;
    }
    public string ConstructDataString()
    {
        string data = "<b>" + gameObject.name + "</b>\n<color=#0473f0>Money Stored:" + moneyStored + "</color>\n\nWorkers: "
            +curWorkers + "/" + maxWorkers+ "\nMaintentence: " + curCleanliness + "/" + maxCleanliness + "\nRevenue: " + revenue;
        return data;
    }
}
