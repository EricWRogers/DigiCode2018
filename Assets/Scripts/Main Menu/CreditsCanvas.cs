﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsCanvas : MonoBehaviour {

    public Canvas mainCanvas;

    public void ButtonMainMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
