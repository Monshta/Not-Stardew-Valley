using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidbody;
    //private float hitTime;
    //public bool vulnerable = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > .5 /*&& vulnerable == true*/ || Input.GetAxisRaw("Horizontal") < -0.5f /*&& vulnerable == true*/)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > .5 /*&& vulnerable == true*/ || Input.GetAxisRaw("Vertical") < -0.5f /*&& vulnerable == true*/)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * speed);
        }
        if (Input.GetAxisRaw("Horizontal") < .5f && Input.GetAxisRaw("Horizontal") > -.5f)
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < .5f && Input.GetAxisRaw("Vertical") > -.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        }
    }
    /*IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        vulnerable = true;
    }*/

    /*void OnCollisionStay2D (Collision2D Enemyhit)
    {
       if(Enemyhit.gameObject.tag == "Enemy")
        {
            float verticalpush = Enemyhit.gameObject.transform.position.y - transform.position.y;
            float horizontalpush = Enemyhit.gameObject.transform.position.x - transform.position.x;
            vulnerable = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalpush, -verticalpush) * 50);
            StartCoroutine(HitTimer());
        }
    }*/
}
