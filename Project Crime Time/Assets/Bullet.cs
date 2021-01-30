using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject bullet;
    public int bulletTime = 5;
    private int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

//    private void Update()
//    {
//        while (x != bulletTime)
//        {
//            x = x + 1;
//        } 
//        else
//        {
//            Destroy(bullet);
//        }
//    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(bullet);
    }

}
