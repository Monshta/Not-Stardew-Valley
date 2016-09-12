using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {
    GameObject sleepConfirmPanel;
	// Use this for initialization
	void Start () {
        sleepConfirmPanel = GameObject.Find("SleepConfirmPanel");
        sleepConfirmPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        sleepConfirmPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SleepConfirmYesBtn()
    {
        Time.timeScale = 1;
        GameObject.Find("Controller").GetComponent<Persistence>().SaveAll();
        GameObject.Find("HUD").GetComponent<HUDScript>().NewDay();
        sleepConfirmPanel.SetActive(false);
    }
    
    public void SleepConfirmNoBtn()
    {
        Time.timeScale = 1;
        sleepConfirmPanel.SetActive(false);
    }
}
