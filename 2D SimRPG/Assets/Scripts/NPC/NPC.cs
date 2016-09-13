using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public float moveSpeed;
    public bool isWalking;

    public float walkTime;
    private float walkTimer;
    public float waitTime;
    private float waitTimer;

    private int walkDir;

    private Rigidbody2D myrigidbody;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();


        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        waitTimer = waitTime;
        walkTimer = walkTime;

        ChooseDirection();
	}
	
	void Update () {
	    if (isWalking)
        {
            walkTimer -= Time.deltaTime;
           
            switch (walkDir)
            {
                case 0:
                    myrigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y >= maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitTimer = waitTime;
                    }
                    break;

                case 1:
                    myrigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x >= maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitTimer = waitTime;
                    }
                    break;

                case 2:
                    myrigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                    {
                        isWalking = false;
                        waitTimer = waitTime;
                    }
                    break;

                case 3:
                    myrigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x <= minWalkPoint.y)
                    {
                        isWalking = false;
                        waitTimer = waitTime;
                    }
                    break;
            }

            if (walkTimer <= 0)
            {
                isWalking = false;
                waitTimer = waitTime;
            }

        }
        else
        {
            waitTimer -= Time.deltaTime;
            myrigidbody.velocity = Vector2.zero;
            
            if(waitTimer < 0)
            {
                ChooseDirection();
            }
        }
	}
    
    public void ChooseDirection ()
    {
        walkDir = Random.Range(0, 4);
        isWalking = true;
        walkTimer = walkTime;
    }
}
