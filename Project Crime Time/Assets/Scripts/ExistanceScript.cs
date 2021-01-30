using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistanceScript : MonoBehaviour
{
    public int health = 2;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteBox()
    {
        health = health - 1;

        if (health <= 0)
        {
            Destroy(box);
        }

    }
}
