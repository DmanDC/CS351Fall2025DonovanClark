using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The enemy's health
    public int health = 100;

    //a prefab to spawn when the enemy dies
    public GameObject deathEffect;


    public void TakeDamge(int damage) {
        // Subtract the damage dealt from the health
        health -= damage;

        //if Health is less than or equal to 0
        if(health <=0)
        {
            // call the die function
            Die();
        }

        void Die()
        {
            //spawn deatheffect
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            //Destroy the Enemy
            Destroy(gameObject);
        }
    
    }
}
