using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;//The speed that the bullet travels
    public float liveTime = 2; //The amount of seconds that the bullet will travel for before disappearing
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; //Sets the velocity at the begining of the bullet spawning. (Transform.right means that the velocity is set so that it moves to the right however when the character flips, so does everything and the bullet is shot left thankfully)
    }

    void Update()
    {// This makes it so that the livetime ticks down and when under 0 will delete the bullet
        liveTime -= Time.deltaTime;
        if (liveTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {// This checks that the bullet deletes itself if it hits any object.
        HealthScript collisionObject = hitInfo.GetComponent<HealthScript>(); //This assigns a variable of collisionObject as to whether there is a "HealthScript" component into whatever object the bullet collides with.
        if (collisionObject != null)//If the variable is actually filled with info (meaning it collided with something that has health), then it will run the function inside of the health script which will trigger
        {
            collisionObject.TakeDamage(1);
        }
        
        Destroy(this.gameObject);//Destroys the bullet after contact
    }

}
