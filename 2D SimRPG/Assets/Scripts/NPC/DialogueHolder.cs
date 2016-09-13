using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;

    private Dialogue dialogueManager;

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<Dialogue>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D (Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                dialogueManager.ShowBox(dialogue);
            }
        }
    }
}
