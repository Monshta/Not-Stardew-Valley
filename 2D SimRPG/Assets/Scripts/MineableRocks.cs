using UnityEngine;
using System.Collections;

public class MineableRocks : MonoBehaviour {

    GameObject Parent;
    public int RockAmount = 1;
    Inventory inventory;
    // Use this for initialization
    void Start()
    {
        Parent = gameObject.transform.parent.gameObject;
        inventory = GameObject.Find("ItemDatabase").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Character")
        {
            InvokeRepeating("IfRightClickOnRock", 0, 0.01f);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke();
    }
    void IfRightClickOnRock()
    {
        if (Input.GetMouseButtonDown(1) && MainController.wieldedItem.Title == "Axe")
        {
            RaycastHit2D hitTree = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hitTree == true && hitTree.collider.gameObject == Parent)
            {
                inventory.AddItemByTitle("Rock");
                RockAmount -= 1;
                if (RockAmount == 0)
                {
                    CancelInvoke();
                    Parent.SetActive(false);
                }
            }
        }
    }
}
