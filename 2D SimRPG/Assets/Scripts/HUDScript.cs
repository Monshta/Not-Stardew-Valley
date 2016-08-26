using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    public int maxHP = 10;
    public int maxEnergy = 10;
    public int curHP = 10;
    public int curEnergy = 10;
    public int money = 100;

    string formattedTime;

    TimeSpan timeSpan = TimeSpan.FromHours(11);
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
   
}
