using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buildingStats : MonoBehaviour {
    float cost = 0.0f;
    int inhabitants = 0;

    public Text displayText;
	// Use this for initialization
	void Start () {
        SetDisplayText("Welcome to this game");
	}
	
	// Update is called once per frame
	void Update () {

	}
    //needs collider to work
    void OnMouseDown()
    {
        SetDisplayText(GetCurrentStatString());
    }

    void SetDisplayText(string textString)
    {
        displayText.text = textString;
    }

    string GetCurrentStatString()
    {
        return "This building costs: " + cost.ToString() + " and has " + inhabitants.ToString() + " inhabitants";
    }
    public void UpgradeBuilding()
    {
        cost += 1;
        SetDisplayText(GetCurrentStatString());
    }
}
