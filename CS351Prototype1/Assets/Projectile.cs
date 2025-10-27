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

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody compent
        rb = GetComponent<Rigidbody2D>();

      // set the velocity of the projectile to fire to the right of the speed
      rb.velocity = transform.right * speed;

    }

}
