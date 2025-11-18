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

    // Unique key for this dialog in PlayerPrefs
    public string dialogKey;


    private void OnEnable()
    {
        // If this dialog has already been shown before, skip it
        if (PlayerPrefs.GetInt(dialogKey, 0) == 1)
        {
            DialogPanel.SetActive(false);
            return;
        }

        // disable the continue button
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        textbox.text = "";

        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
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

            // Save that this dialog was shown
            PlayerPrefs.SetInt(dialogKey, 1);
            PlayerPrefs.Save();
        }
    }

}
