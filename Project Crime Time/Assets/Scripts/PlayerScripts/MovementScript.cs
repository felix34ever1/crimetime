using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float LowYAxis = 3;
    public Rigidbody2D rb;
    public BoxCollider2D floorDetector;
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
        groundCollisionScript groundCollisionScript = floorDetector.GetComponent<groundCollisionScript>();//Checks the script of the floordetector object which is a trigger placed below the player to be able to detect if he is touching the ground or not


        if (FacingRight)//the code to face the player the right way and to make them always upright.
        {
            tf.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (!FacingRight)//if not facing right
        {
            tf.rotation = new Quaternion(0, 180, 0, 0);
        }



        if (Input.GetKey("d"))//Adds movement right
        {
            rb.velocity = new Vector2(sidewaysForce*Time.deltaTime,rb.velocity.y);
            if (!FacingRight)
            {
                Flip();
            }
            
        }
        else if (Input.GetKey("a"))//Adds movement left
        {
            rb.velocity = new Vector2(-sidewaysForce * Time.deltaTime, rb.velocity.y);
            if (FacingRight)
            {
                Flip(); 
            }
        }
        else//if the character is not supposed to move(eg the player is not pressing d or a), the velocity of the character's x axis is slowly reduced to 0.
        {
            rb.velocity = new Vector2(rb.velocity.x/1.1f, rb.velocity.y);
        }
        if (tf.position.y > LowYAxis+3) // This is to check if the player has jumped too high in which case his y velocity is reduced so that he starts falling
        {
            rb.velocity = new Vector2(rb.velocity.x, -10);
            
        }

        //Allows for jumping as long as the player is colliding on the ground.
        if (Input.GetKeyDown("w"))
        {
            if (groundCollisionScript.isColliding)//This checks a variable in a separate script
            {
                rb.velocity = new Vector2(rb.velocity.x, upwardsForce * Time.deltaTime);
            }
        }
        LowYAxis = tf.position.y;

    }

    private void OnCollisionStay2D(Collision2D collision)

    {
        //Allows for jumping as long as the player is colliding.
        //Need to make it so that it has to only be colliding on the floor so it can't wall jump or stuff. (Unless we want to do that)
        //Bug: can spam w while on the side of the wall and player will get flung up.


    }
    
    //Just changes a variable to check if the player is facing right or not. Then that variable is used back in the update() code to check what direction to face.
    private void Flip()
    {
        FacingRight = !FacingRight;
    }
}
