using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    Direction currentDir;
    Vector2 input;
    Vector3 startPos;
    Vector3 endPos;
    float time;

    public float walkSpeed = 4f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Mathf.Abs(input.x)> Mathf.Abs(input.y))
        {
            input.y = 0;
        }
        else
        {
            input.x = 0;
        }
        if(input != Vector2.zero)
        {
            StartCoroutine(Move(transform));
        }
        transform.rotation = Quaternion.Euler(0,0,0);
    }
    public IEnumerator Move (Transform entity)
    {
        startPos = entity.position;
        time = 0;
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);
        time += Time.deltaTime * walkSpeed;
        entity.position = Vector3.Lerp(startPos, endPos, time);
        yield return 0;
    }
}

enum Direction
{
    North,
    East,
    South,
    West
}
