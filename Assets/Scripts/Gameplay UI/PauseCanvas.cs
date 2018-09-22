using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour {

    public Canvas mainCanvas, HTPCanvas;

    public void ButtonReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonHTP()
    {
        HTPCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButtonContinue()
    {
        Time.timeScale = 1f;
        mainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
