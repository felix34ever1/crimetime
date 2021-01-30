using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistanceScript : MonoBehaviour
{
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
        Destroy(box);
    }
}
