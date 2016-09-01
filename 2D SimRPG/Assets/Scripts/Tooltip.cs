using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }
    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }
    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<b>" +item.Title + "</b>\n<color=#0473f0>" + item.Type + "</color>\n\n" + item.Description;
        if (item.Equipable)
        {
            data += "\n\nAttack: " + item.Attack + " Defense: " + item.Defense; 
        }
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
