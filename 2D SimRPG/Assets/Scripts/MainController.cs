using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainController : MonoBehaviour {
    public static GameObject currentObject;
    public static Text displayText;
    // Use this for initialization
    void Start () {
        displayText = GameObject.Find("DisplayTxt").GetComponent<Text>();
        SetDisplayText("Welcome to this game");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void setSelectedObject(GameObject obj)
    {
        currentObject = obj;
    }

    public static GameObject getSelectedObject()
    {
        return currentObject;
    }

    public static void SetDisplayText(string textString)
    {
        displayText.text = textString;
    }
}
