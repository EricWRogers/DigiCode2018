using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayCanvas : MonoBehaviour {

    public Canvas mainCanvas;
    public GameObject[] display;
    public Button back, forward;
    int currentDisplay;

	public void ButtonMainMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButtonBack()
    {
        if (currentDisplay > 0)
        {
            forward.gameObject.SetActive(true);
            display[currentDisplay].SetActive(false);
            currentDisplay--;
            display[currentDisplay].SetActive(true);
            if (currentDisplay == 0)
            {
                back.gameObject.SetActive(false);
            }
        }
    }

    public void ButtonForward()
    {
        if (currentDisplay < display.Length-1)
        {
            back.gameObject.SetActive(true);
            display[currentDisplay].SetActive(false);
            currentDisplay++;
            display[currentDisplay].SetActive(true);
            if (currentDisplay == display.Length-1)
            {
                forward.gameObject.SetActive(false);
            }
        }
    }
}
