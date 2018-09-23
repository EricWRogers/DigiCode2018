using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour{

    public static GameLogic Instance;
    public int currentCollected = 0;
    public int collectedNeeded = 0;
    public GameObject holding = null;

    public int timer = 90;
    public int bonusTime = 15;
    public float timerSeconds;
    public int timerMinutes;

    public Canvas mainCanvas, winCanvas, loseCanvas, pauseCanvas;
    public List<GameObject> collectables = new List<GameObject>();

    public Vector3 startPos, enemyStartPos, heldPos;
    GameObject plr;
    Animator anim;

    public void Start()
    {
        Time.timeScale = 1f;
        Instance = this;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            collectables.Add(obj);
            collectedNeeded++;
        }
        collectables.TrimExcess();
        timerMinutes = timer / 60;
        timerSeconds = timer % 60;
        plr = GameObject.FindGameObjectWithTag("Player");
        startPos = plr.transform.position;
        enemyStartPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
        anim = plr.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mainCanvas.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0f;
            mainCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(true);
        }
        timerSeconds -= Time.deltaTime;
        if (timerSeconds < 0f)
        {
            if (timerMinutes > 0)
            {
                timerMinutes--;
                timerSeconds += 60f;
            } else
            {
                Time.timeScale = 0f;
                mainCanvas.gameObject.SetActive(false);
                loseCanvas.gameObject.SetActive(true);
            }
        }
        if (holding)
        {
            holding.transform.position = plr.transform.position + Vector3.up*2.5f;
            holding.transform.rotation = plr.transform.rotation;
            anim.SetBool("holding", true);
        }
    }

    public void PickUp(GameObject obj)
    {
        if (!holding)
        {
            // If we're not holding a collectable, pick it up
            heldPos = obj.transform.position;
            holding = obj;
        }
    }

    public void Drop()
    {
        if (holding)
        {
            // If we're holding a collectable, drop it
            holding.transform.position = heldPos;
            holding = null;
            anim.SetBool("holding", false);
        }
    }

    public void Collect()
    {
        if (holding)
        {
            // If we're holding a collectable when this function is called, add it to the collectable count
            Destroy(holding);
            holding = null;
            anim.SetBool("holding", false);
            currentCollected++;
            if (currentCollected == collectedNeeded)
            {
                Time.timeScale = 0f;
                mainCanvas.gameObject.SetActive(false);
                winCanvas.gameObject.SetActive(true);
            } else
            {
                timerSeconds += 15f;
                if (timerSeconds >= 60)
                {
                    timerMinutes++;
                    timerSeconds -= 60f;
                }
            }
        }
    }
}
