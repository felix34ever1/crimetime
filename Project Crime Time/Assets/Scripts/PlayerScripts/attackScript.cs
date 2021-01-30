using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class attackScript : MonoBehaviour
{
    public Transform firePoint;//the transform of the firepoint.
    public GameObject bulletPrefab;//the gameobject for the bullet prefab so it can be spawned in.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        //Currently it spawns a bullet at the firepoint which is on the front of the player.
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }



}
