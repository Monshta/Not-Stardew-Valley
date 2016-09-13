using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;
    public bool isPlaceable;
    public int placementcost = 1;
    int money;
    // Update is called once per frame
    void Start()
    {
        money = GameObject.Find("HUD").GetComponent<HUDScript>().money;
    }
    void Update () { 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Floor(mousePos.x), Mathf.Floor(mousePos.y));

        if (Input.GetMouseButtonDown(0) && isPlaceable == true && money > placementcost)
        {
            Instantiate(finalObject, transform.position, Quaternion.identity);
            GameObject.Find("HUD").GetComponent<HUDScript>().moneyDown(placementcost);
            money = GameObject.Find("HUD").GetComponent<HUDScript>().money;
            gameObject.SetActive(false);
        }
	}

    void OnTriggerStay2D (Collider2D other)
    {
        if(other.gameObject.tag == "Building")
        {
            isPlaceable = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            isPlaceable = true;
        }
    }

    public void ChooseBuilding ()
    {
        gameObject.SetActive (true);
    }
}
