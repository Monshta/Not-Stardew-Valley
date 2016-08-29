using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    //private float hitTime;
    //public bool vulnerable = true;

	void Update ()
    {
       if (Input.GetAxisRaw("Horizontal") > .5 /*&& vulnerable == true*/ || Input.GetAxisRaw("Horizontal") < -0.5f /*&& vulnerable == true*/)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }

       if (Input.GetAxisRaw("Vertical") > .5 /*&& vulnerable == true*/ || Input.GetAxisRaw("Vertical") < -0.5f /*&& vulnerable == true*/)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
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
