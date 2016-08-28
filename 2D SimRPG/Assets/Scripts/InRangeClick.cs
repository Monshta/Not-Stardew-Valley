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
            InvokeRepeating("IfRightClick", 0, 0.01f);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke();
    }

    void IfRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit.collider.gameObject == Parent)
            {
                Parent.GetComponent<buildingStats>().CollectMoneyStored();
                CancelInvoke();
            }
        }
    }
} 
