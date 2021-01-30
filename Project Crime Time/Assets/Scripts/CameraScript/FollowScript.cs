using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform CameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float camerax = PlayerTransform.position.x;
        float cameray = PlayerTransform.position.y;
        float cameraz = PlayerTransform.position.z-10;
        CameraTransform.position = new Vector3(camerax,cameray,cameraz);
    }
}
