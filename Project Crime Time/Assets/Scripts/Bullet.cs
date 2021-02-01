using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject bullet;
    public float liveTime = 2;
    private int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HealthScript box = hitInfo.GetComponent<HealthScript>();
        if (box != null)
        {
            box.DeleteBox();
        }
        
        Destroy(bullet);
    }

}
