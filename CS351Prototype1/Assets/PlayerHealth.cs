using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variable to store the health of the player {
    public int health = 100;

    //reference to the health bar
    //This must be set in the inspector
    public DisplayBar healthBar;

    //referce to the player's rigidbody2D
    //We need this to apply knockback  force to the player
    private Rigidbody2D rb;

    //variable to keep track of the knockback force when the player colides with enemy
    public float knockbackForce = 5f;

    // a prefab to spawn when the player dies
    //this must be set in the inspector
    public GameObject playerDeathEffect;

    // bool to keep tract of if the player been hit recently
    public static bool hitRecently = false;

    //Time to seconds to recover from hit
    public float hitRecoveryTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
      // set the rigidbody2d reference
      rb = GetComponent<Rigidbody2D>();

        // check if the rigidbody2d reference is null
        if (rb == null ) {
            Debug.LogError("Rigidbody2D not found on player");
        }
        //set healthbar max value to the players health
        healthBar.SetMaxValue(health);

        //initailize hitRecently to flase
        hitRecently = false;
    }

    //A function to knock the player back when the collide with and enemy
    public void Knockback(Vector3 enemyPosition)
    {
        //if the player has been hit recently 
        if (hitRecently)
        {
            //return out of this function
            return;
        }
        //set hitRecently to true 
        hitRecently = true;

        // Start the coroutinr to reset hitRecently
        StartCoroutine(RecoverFromHit());

        //Calculate the direction of the knockback
        Vector2 direction = transform.position - enemyPosition;

        // normalize the direction vector
        // this gives consistent knockback force regardless of the distance
        // between the player and the enemy
        direction.Normalize();

        // adds upward direction to the knockback
        direction.y = direction.y * 0.5f + 0.5f;

        //adds force to the player in the direction of the knockback
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

    }
    // Coroutine to rest hitRecently after hitRecoveryTime seconds
    IEnumerator RecoverFromHit()
    {
        //Wait for hitRecoveryTime (0.2) seconds
        yield return new WaitForSeconds(hitRecoveryTime);

        //Set hitRecently to false
        hitRecently = false;
    }

    public void TakeDamage(int damage)
    {
        //subtract the Damage from the health 
        health -= damage;

        // update healthbar
        healthBar.SetValue(health);

    //Todo: play a sound effect when the player takes damage
    // Todo: play an animation when player takes damage

        // if the health is less than or equal to zero
        if(health <= 0)
        {
            // call the die method
            Die();
        }
    }

    public void Die()
    {
        //set GameOver to true 
        ScoreManager.gameOver = true;

        // ToDo: play a sound effect when the player dies
        //ToDo: add the player deatheffect when the player dies

        //Instantiate the Dalth effect at the players's position
// GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        //Destroy the death effect after 2 seconds
       // Destory(deathEffect, 2f);

        //Disable the player object 
        gameObject.SetActive(false);


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
