using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartGame()
  {
    SceneManager.LoadScene("Office");
  }

  public void ExitGame()
  {
    Debug.Log("Game closed");
    Application.Quit();
  }
}
