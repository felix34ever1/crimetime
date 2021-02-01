using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int health = 2;
    public int damageAmount = 3;
    public GameObject go;//game object. Suppossed to be itself
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)//The function that calculates damage damage.
    {
        health = health - damageAmount;

        if (health <= 0)
        {
            Destroy(go);
        }

    }
}
