using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]

public class Portal : MonoBehaviour {
 
    public string sceneToTeleport;

    void OnTriggerEnter (Collider other) {
        SceneManager.LoadScene(sceneToTeleport);
    }
}