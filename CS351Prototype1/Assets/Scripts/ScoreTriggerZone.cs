using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    //set this referecne to the jump sound in the the inspector
    public AudioClip scoreSound;

    //an audio source to play sound effects
    private AudioSource playerAudio;

    //a bool variable to keep tract of if the trigger zone is 
    bool active = true;

    private void Start()
    {
        //Set reference to player audio source
        playerAudio = GetComponent<AudioSource>();

    }

        private void OnTriggerEnter2D (Collider2D collision)
    {
        //if the trigger zone is active...
        if (active && collision.gameObject.tag == "Player")
        {
            //Deativate the trigger zone
            active = false;
            //Add 1 to the score when the plaer enters the trigger
            ScoreManager.score++;

            //Play score sound effect
            playerAudio.PlayOneShot(scoreSound, 1.0f);

            //make it diapper
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;

            //Destory this GameObject;
            Destroy(gameObject, 2.0f);
        }
        

    }
}
