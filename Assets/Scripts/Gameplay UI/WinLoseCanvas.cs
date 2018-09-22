using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCanvas : MonoBehaviour {

    public string nextSceneName;
    
    public void ButtonNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void ButtonReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
