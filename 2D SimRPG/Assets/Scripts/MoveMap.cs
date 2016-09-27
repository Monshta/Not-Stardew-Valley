using UnityEngine;
using System.Collections;

public class MoveMap : MonoBehaviour {
    public GameObject SpawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Character")
        {
            InvokeRepeating("IfRightClickOnDoor", 0, 0.01f);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke();
    }
    void IfRightClickOnDoor()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hitTree = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hitTree == true && hitTree.collider.gameObject == gameObject)
            {
                GameObject character = GameObject.Find("Character");
                character.transform.position = SpawnPoint.transform.position;
                GameObject.Find("Main Camera").GetComponent<CameraController>().xCon = new Vector3(64.2f, 65.7f, 0);
                GameObject.Find("Main Camera").GetComponent<CameraController>().yCon = new Vector3(0.1f, 2f, 0);
            }
        }
    }
}
