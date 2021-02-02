using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject go; // The game object of itself.
    public GameObject player;// the gameobject of the player.
    public int range; // the range that the detection of the enemy will be

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void detect()
    {
        RaycastHit2D hit2D;//will once correctly created, shoot out raycast to detect player!
        if (Physics2D.Raycast(go.transform.position, go.transform.transform.right, out hit2D, range))
        {
            Debug.Log(hit2D.transform.name);
        }
    }
}
