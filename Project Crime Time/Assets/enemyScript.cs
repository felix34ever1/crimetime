using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject go; // The game object of itself.
    public Rigidbody2D rb; // The rigid body of the object itself
    public Transform player;// the gameobject of the player.
    public int range; // the range that the detection of the enemy will be
    public float movementSpeed = 5f; //The movement speed of the enemy.
    public Transform CastPoint; // Where the raycasting will be shot from on the enemy
    bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);//This is the current distance that the enemy is to the player
        if (distToPlayer < 5)//If the enemy is within this much range of the player
        {
            if (canSeePlayer(range))//if the player can be seen with no obstructions in the way
            {
                chasePlayer();//The enemy will go towards the player
            }
            else
            {
                stopChasingPlayer(); //The enemy will stop going towards the player
            }
        }
        else
        {
            stopChasingPlayer();//The enemy will stop going towards the player
        }

        if (transform.position.x < player.position.x)//Calculation to find out if player is to the right of the enemy
        {
            transform.rotation = new Quaternion(0, 0, 0, 0); //Makes the enemy upright and facing the player
            isFacingRight = true;
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);//Makes the enemy upright and facing player
            isFacingRight = false;
        }
    }

    void chasePlayer()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(movementSpeed * Time.deltaTime, 0);//Moves the enemy towards the x axis of the player (right)
        }
        else
        {
            rb.velocity = new Vector2(-movementSpeed * Time.deltaTime, 0);//Moves the enemy towards the x axis of the player (left)
        }
    }


    void stopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);//Will make the velocity nothing if this is ran
    }


    bool canSeePlayer(float distance)
    {
        bool val = false;//Variable that will be returned at the end of the function
        float castDist = distance;//The distance that the raycast will go to max

        if (!isFacingRight)
        {
            castDist = -distance;
        }

        Vector2 endPos = CastPoint.position + Vector3.right * castDist;//This is the same as saying new Vector3(position.x + distance,position.y,position.z)
        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position,endPos,1 << LayerMask.NameToLayer("Action"));//This will shoot out a raycast line and store the data in the variable hit.
        //The raycast is defined as starting position,end poistion, will only be stopped by GameObjects with this layer
        if (hit.collider != null)//if the collision detection hit something e.g isnt null:
        {
            if (hit.collider.gameObject.CompareTag("Player"))//if the collided object has the tag "player":
            {
                //It will agro the Enemy
                val = true;//changes the value to true representing it can see the player
            }
            else
            {
                //Will unagro the Enemy.
                val = false;//Changes value to false representing it cannot see the player
            }
            Debug.DrawLine(new Vector3(CastPoint.position.x,CastPoint.position.y,CastPoint.position.z), hit.point, Color.red);//Creates a debug drawing on screen to represent the raycast, the red indicating it is in contact with something

        }
        else
        {
            Debug.DrawLine(CastPoint.position, endPos, Color.yellow);//creates a debug drawing on the screen to represent the raycast, with the yellow signifying it does not detect anything.

        }


        return (val);
    }

}
