using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainController : MonoBehaviour {
    public static GameObject currentObject;
    public static GameObject displayPnl;
    public static Text displayText;
    GameObject InventoryPanel;
    public static Item wieldedItem;

    private Inventory inventory;
    // Use this for initialization
    void Start () {
        displayText = GameObject.Find("DisplayTxt").GetComponent<Text>();
        displayPnl = GameObject.Find("DisplayPnl");
        SetDisplayText("Welcome to this game");

        InventoryPanel = GameObject.Find("ItemDatabase").GetComponent<Inventory>().InventoryPanel;
        inventory = GameObject.Find("ItemDatabase").GetComponent<Inventory>();
        wieldedItem = inventory.getWieldedItem();

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
        displayPnl.SetActive(true);
        displayText.text = textString;
    }

    public void ActivateInventoryPanel()
    {
        Time.timeScale = 0;
        InventoryPanel.SetActive(true);
    }
    public void DeactivateInventoryPanel()
    {
        Time.timeScale = 1;
        InventoryPanel.SetActive(false);
    }
}
