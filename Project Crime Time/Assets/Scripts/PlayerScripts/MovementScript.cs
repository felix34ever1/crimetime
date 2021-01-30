using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform tf;

    public float sidewaysForce = 1000f;
    public float upwardsForce = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tf.rotation = new Quaternion(0, 0, 0, 0 ); //This makes the rotation always that< and so it stays upright.
        if (Input.GetKey("d"))//Adds movement right
        {
            rb.AddForce(new Vector2(sidewaysForce*Time.deltaTime,0f));
        }
        if (Input.GetKey("a"))//Adds movement left
        {
            rb.AddForce(new Vector2(-sidewaysForce * Time.deltaTime, 0f));
        }

 
    }
    //Allows for jumping as long as the player is colliding.
    //Need to make it so that it has to only be colliding on the floor so it can't wall jump or stuff. (Unless we want to do that)

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(new Vector2(0f, upwardsForce * Time.deltaTime));
        }
    }

}
