using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private string quizToTeleport;

    public void Speech(Sprite p, string[] txt, string actorName, string quizToTeleport) {
        this.quizToTeleport = quizToTeleport;
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence() {
        foreach (char letter in sentences[index].ToCharArray()) {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {
        if(speechText.text == sentences[index]) {
            if(index < sentences.Length - 1) {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            } else {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                SceneManager.LoadScene(this.quizToTeleport);
            }
        }
    }

    public void QuitDialogue() {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
    }
}
