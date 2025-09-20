using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add this to work with TextMeshpro
using TMPro;
//Add this to work with SceneManager to loard or reload scenes
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Notice public static variables can be acess from any scipt
    //but cannot be seen in the Insepctor
    public static bool gameOver;
    public static bool won;
    public static int score;

    //set this this in the inspector
    public TMP_Text textbox;

    //set this to the score needed to win in the inspector
    public int scoreToWin;

    //Set initial values for variables in Start()

    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if(score >= scoreToWin)
        {
            won = true;
            gameOver = true;
        }

        if (gameOver)
        {
            if(won)
            {
                //display you Win! text
                textbox.text = "You Win\nPress R tp Try Again!";
            }
            else
            {
                //display you Lose! text
                textbox.text = "You Lose\nPress R tp Try Again!";

            }

            //if they press r key, reload scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
