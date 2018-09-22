using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour{

    public static GameLogic Instance;
    public int currentCollected = 0;
    public int collectedNeeded = 0;
    public GameObject holding;

    public int timer = 90;
    public float timerSeconds;
    public int timerMinutes;

    public Canvas mainCanvas, winCanvas, loseCanvas, pauseCanvas;

    public void Start()
    {
        Time.timeScale = 1f;
        Instance = this;
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("Collectable"))
            {
                collectedNeeded++;
            }
        }
        timerMinutes = timer / 60;
        timerSeconds = timer % 60;
    }

    private void Update()
    {
        timerSeconds -= Time.deltaTime;
        if (timerSeconds < 0f)
        {
            if (timerMinutes > 0)
            {
                timerMinutes--;
            } else
            {
                Time.timeScale = 0f;
                mainCanvas.gameObject.SetActive(false);
                loseCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void PickUp(GameObject obj)
    {
        if (!holding)
        {
            // If we're not holding a collectable, pick it up
            holding = obj;
        }
    }

    public void Drop()
    {
        if (holding)
        {
            // If we're holding a collectable, drop it
            holding = null;
        }
    }

    public void Collect()
    {
        if (holding)
        {
            // If we're holding a collectable when this function is called, add it to the collectable count
            Destroy(holding);
            holding = null;
            currentCollected++;
            if (currentCollected == collectedNeeded)
            {
                Time.timeScale = 0f;
                mainCanvas.gameObject.SetActive(false);
                winCanvas.gameObject.SetActive(true);
            }
        }
    }
}
