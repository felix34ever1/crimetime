using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform tf;
    bool FacingRight = true;
    public float sidewaysForce = 1000f;
    public float upwardsForce = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (FacingRight)//the code to face the player the right way and to make them always upright.
        {
            tf.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (!FacingRight)
        {
            tf.rotation = new Quaternion(0, 180, 0, 0);
        }



        if (Input.GetKey("d"))//Adds movement right
        {
            rb.AddForce(new Vector2(sidewaysForce*Time.deltaTime,0f));
            if (!FacingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey("a"))//Adds movement left
        {
            rb.AddForce(new Vector2(-sidewaysForce * Time.deltaTime, 0f));
            if (FacingRight)
            {
                Flip(); 
            }
        }

 
    }

    private void OnCollisionStay2D(Collision2D collision)
    //Allows for jumping as long as the player is colliding.
    //Need to make it so that it has to only be colliding on the floor so it can't wall jump or stuff. (Unless we want to do that)
    //Bug: can spam w while on the side of the wall and player will get flung up.
    {
        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector2(0f, upwardsForce * Time.deltaTime));
        }
    }
    
    //Just changes a variable to check if the player is facing right or not. Then that variable is used back in the update() code to check what direction to face.
    private void Flip()
    {
        FacingRight = !FacingRight;
    }
}
