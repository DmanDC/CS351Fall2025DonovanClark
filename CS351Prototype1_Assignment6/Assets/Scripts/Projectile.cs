using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// projectile class that controls the movement of the projectile
//attach this script to tje projectile prefab
public class Projectile : MonoBehaviour
{
    //Rigidbody component os the projectile
    private Rigidbody2D rb;

    //speed of the projectile with a default value of 20
    public float speed = 20f;

    //Damage of the projectile with a deafult of 20
    public int damage = 20;

    //Impact effect of the projectile
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody compent
        rb = GetComponent<Rigidbody2D>();

      // set the velocity of the projectile to fire to the right of the speed
      rb.velocity = transform.right * speed;

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Get the enemey component of the object that was hit
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        //if the object that hit has an Enemy component 
        if (enemy != null)
        {

            //call the TakeDamage function of the enemy component 
            enemy.TakeDamge(damage);

        }

        // if the object that was hit is not the player
        if(hitInfo.gameObject.tag != "Player")
        {
            //Insantiate the impactEffect
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            //Destroy the projectile
            Destroy(gameObject);
        }
    }

}
