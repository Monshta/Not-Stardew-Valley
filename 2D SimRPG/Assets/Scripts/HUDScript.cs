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
    float time = 0.00f;

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
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        timeTxt.text = "Time: " + formattedTime;
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
