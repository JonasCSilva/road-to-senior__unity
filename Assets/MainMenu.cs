using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void InitGame()
    {
        SceneManager.LoadScene("Office");
    }
    
    public void QuitGame()
    {
        Debug.Log("Saiu Do Jogo");
        Application.Quit();
    }
}
