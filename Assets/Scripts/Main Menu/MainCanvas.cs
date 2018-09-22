using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour {

    public Canvas levelSelectCanvas, howToPlayCanvas, creditsCanvas;

    public void ButtonLevelSelect()
    {
        levelSelectCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButtonHowToPlay()
    {
        howToPlayCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButtonCredits()
    {
        creditsCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
