﻿using System.Collections;
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



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ExistanceScript box = hitInfo.GetComponent<ExistanceScript>();
        if (box != null)
        {
            box.DeleteBox();
        }
        
        Destroy(bullet);
    }

}