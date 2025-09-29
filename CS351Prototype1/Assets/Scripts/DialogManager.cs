using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Must add this using statment to use TMP_Text
using TMPro;
using UnityEngine.Analytics;
public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject DialogPanel;

    private void OnEnable()
    {
        //disable the continue button
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    //Coroutine to type one letter at a time in the dialog box
    IEnumerator Type()
    {
        //start the textbox as em
        textbox.text = "";

        // loop though th esentence adding one letter at a time
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        //Enable contine button
        continueButton.SetActive(true);

    }

    public void NextSentence()
    {
        //Disable the contine button
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else 
        {
            textbox.text = "";
            DialogPanel.SetActive(false);
        }
    }
}
