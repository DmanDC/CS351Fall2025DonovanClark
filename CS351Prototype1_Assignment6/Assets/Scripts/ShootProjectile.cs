using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    //Reference to the projectile prefab
    public GameObject projectilePrefab;

    //reference to the first fire poings transform 
    //this is where the projectiles will be instatiated
    public Transform firePoint;

   

    // Update is called once per frame
    void Update()
    {
      // if the player plresses the fire buton
      // //call the shoot function
      if(Input.GetButtonDown("Fire1"))
        {
            // call the shoot function
            Shoot();
        }
    }



    void Shoot()
    {
        // instantiate the projectiles at the fire point position and rotation
        GameObject firedProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //Destroy the projectile after 3 seconds
        Destroy(firedProjectile, 3f);
    }
}
