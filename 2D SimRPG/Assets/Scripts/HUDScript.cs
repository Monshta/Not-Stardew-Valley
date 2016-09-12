using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class HUDScript : MonoBehaviour {
    public int maxHP = 10;
    public int maxEnergy = 10;
    public int curHP = 10;
    public int curEnergy = 10;
    public int money = 100;

    string formattedTime;
    TimeSpan timeSpan = TimeSpan.FromDays(1);
    TimeSpan startHour = TimeSpan.FromHours(7);
    TimeSpan minutes = TimeSpan.FromMinutes(10);
    Text timeTxt;
    Text healthTxt;
    Text energyTxt;
    Text moneyTxt;
	// Use this for initialization
	void Start () {
        timeTxt = GameObject.Find("Time").GetComponent<Text>();
        healthTxt = GameObject.Find("Health").GetComponent<Text>();
        energyTxt = GameObject.Find("Energy").GetComponent<Text>();
        moneyTxt = GameObject.Find("Money").GetComponent<Text>();
        updateHUD();

        //Set up game time
        timeSpan = timeSpan.Add(startHour);
        formattedTime = string.Format("{0:D2} {1:D2}:{2:D2} AM", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
        timeTxt.text = "Day: " + formattedTime;
        InvokeRepeating("addMin", 7.5F, 7.5F);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //adds 10 min every 7.5s and accounts for edge cases for readable time
    public void addMin()
    {
        timeSpan = timeSpan.Add(minutes);
        if(timeSpan.Hours == 12)
        {
            formattedTime = string.Format("{0:D2} {1:D2}:{2:D2} PM", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
        }
        else if (timeSpan.Hours > 12)
        {
             formattedTime = string.Format("{0:D2} {1:D2}:{2:D2} PM", timeSpan.Days, (timeSpan.Hours - 12), timeSpan.Minutes);
        }
        else
        {
            formattedTime = string.Format("{0:D2} {1:D2}:{2:D2} AM", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
        }
        timeTxt.text = "Day: " + formattedTime;
    }
    public void NewDay()
    {
        Time.timeScale = 0;
        timeSpan = TimeSpan.FromDays(timeSpan.Days + 1);
        timeSpan = timeSpan.Add(startHour);
        formattedTime = string.Format("{0:D2} {1:D2}:{2:D2} AM", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
        timeTxt.text = "Day: " + formattedTime;
        Time.timeScale = 1;
    }
    public void updateHUD()
    {
        healthTxt.text = "Health: " + curHP + "/" + maxHP;
        energyTxt.text = "Energy: " + curEnergy + "/" + maxEnergy;
        moneyTxt.text = "Money: " + money;
    }

    public void healthDown(int down)
    {
        curHP -= down;
        updateHUD();
    }

    public void healthUP( int up)
    {
        curHP += up;
        updateHUD();
    }

    public void energyDown(int down)
    {
        curEnergy -= down;
        updateHUD();
    }

    public void energyUP(int up)
    {
        curEnergy += up;
        updateHUD();
    }

    public bool moneyDown(int down)
    {
        if (money > down)
        {
            money -= down;
            updateHUD();
            return true;
        }
        else
            return false;
    }

    public void moneyUp(int up)
    {
        money += up;
        updateHUD();
    }
   public void Save()
    {
        HudData hudData = new HudData();
        hudData.maxHP = maxHP;
        hudData.maxEnergy = maxEnergy;
        hudData.curHP = curHP;
        hudData.curEnergy = curEnergy;
        hudData.money = money;
        File.WriteAllText(Application.persistentDataPath+"/hudData.json", JsonMapper.ToJson(hudData).ToString());
    }
    public void Load()
    {
        JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/hudData.json"));
        this.maxHP = (int)jsonData["maxHP"];
        this.maxEnergy = (int)jsonData["maxEnergy"];
        this.curHP = (int)jsonData["curHP"];
        this.curEnergy = (int)jsonData["curEnergy"];
        this.money = (int)jsonData["money"];
        updateHUD();
    }
}

class HudData{
    public int maxHP;
    public int maxEnergy;
    public int curHP;
    public int curEnergy;
    public int money;
}