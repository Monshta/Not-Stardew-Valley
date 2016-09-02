using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;
    public bool isPlaceable;

    // Update is called once per frame
    void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Floor(mousePos.x), Mathf.Floor(mousePos.y));

        if (Input.GetMouseButtonDown(0) && isPlaceable == true)
        {
            Instantiate(finalObject, transform.position, Quaternion.identity);
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
}
