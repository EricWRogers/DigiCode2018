using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour{

    public static GameLogic Instance;
    public int currentCollected = 0;
    public int collectedNeeded = 0;
    public GameObject holding;
	public static int endTime = 0;
	public static int startTime;
	public Text timerText;

    public void Start()
    {
		StartCoroutine(TimerTracker());
        Instance = this;
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("Collectable"))
            {
                collectedNeeded++;
            }
        }
    }

	IEnumerator TimerTracker(){
		while (enabled){
			endTime = (int)Time.time - startTime;
			timerText.text = "Timer: " + endTime;
			yield return new WaitForSeconds(1);
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
                //Win game if we have all collectables
            }
        }
    }
}
