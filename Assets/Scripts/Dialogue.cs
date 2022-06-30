using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    public string quizToTeleport;

    private DialogueControl dc;

    public void OnTriggerEnter (Collider other) {
        dc = FindObjectOfType<DialogueControl>();
        dc.Speech(profile, speechTxt, actorName, quizToTeleport);
    }
}
