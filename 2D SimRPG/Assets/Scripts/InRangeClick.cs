using UnityEngine;
using System.Collections;

public class InRangeClick : MonoBehaviour {
    GameObject Parent;

    // Use this for initialization
    void Start () {
         Parent = gameObject.transform.parent.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Character")
        {
            InvokeRepeating("IfLeftClick", 0, 0.01f);
            InvokeRepeating("IfRightClick", 0, 0.02f);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke();
    }

    void IfLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit == true && hit.collider.gameObject == Parent)
            {
                Parent.GetComponent<buildingStats>().CollectMoneyStored();
                CancelInvoke("IfLeftClick");
            }
        }
    }
    void IfRightClick()
    {
        if (Input.GetMouseButtonDown(1) && MainController.wieldedItem.Title == "Axe")
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit == true && hit.collider.gameObject == Parent)
            {
                Parent.GetComponent<buildingStats>().Repair();
            }
        }
    }

} 
