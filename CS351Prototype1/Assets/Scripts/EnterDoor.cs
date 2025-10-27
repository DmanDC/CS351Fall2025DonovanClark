using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;
   private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.GetComponent<sign_door>())
        {
            sceneToLoad = "PracticeLevel2";
            enterAllowed = true;
        }
else if (collision.GetComponent<sign_door2>())
        {
            sceneToLoad = "PlatformerStart";
                enterAllowed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<sign_door>() || collision.GetComponent<sign_door2>())
        {
            enterAllowed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
      if(enterAllowed && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
