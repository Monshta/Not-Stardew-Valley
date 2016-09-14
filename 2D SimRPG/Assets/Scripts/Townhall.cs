using UnityEngine;
using System.Collections;

public class Townhall : MonoBehaviour {
    GameObject townHallConatiner;
    GameObject townHallRubble;
    GameObject townHall;
    public int townHallLevel;
    public int buildCost = 1;
    Tooltip tooltip;
	// Use this for initialization
	void Start () {
        townHallConatiner = GameObject.Find("TownHallContainer");
        townHallRubble = townHallConatiner.transform.GetChild(0).gameObject;
        townHall = townHallConatiner.transform.GetChild(1).gameObject;
        townHallLevel = 0;
        townHall.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseOver()
    {
        tooltip = GameObject.Find("ItemDatabase").GetComponent<Tooltip>();
        if(townHallLevel == 0 && Time.timeScale > 0.0f)
            tooltip.Activate("Looks like something was built here.\nClick to build!\nCost: " + buildCost);
    }
    public void OnMouseExit()
    {
        tooltip = GameObject.Find("ItemDatabase").GetComponent<Tooltip>();
        tooltip.Deactivate();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Character" && townHallLevel == 0)
        {
            InvokeRepeating("IfRightClick", 0, 0.01f);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke();
    }

    void IfRightClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int money = GameObject.Find("HUD").GetComponent<HUDScript>().money;
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit == true && hit.collider.gameObject == townHallConatiner && money > buildCost)
            {
                GameObject.Find("HUD").GetComponent<HUDScript>().moneyDown(buildCost);
                townHallRubble.SetActive(false);
                townHall.SetActive(true);
                townHallLevel = 1;
                CancelInvoke();
            }
        }
    }
}
