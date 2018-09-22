using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update () {
        string secs = ((int)GameLogic.Instance.timerSeconds).ToString();
        if (GameLogic.Instance.timerSeconds < 10f)
        {
            secs = "0"+secs;
        }
        txt.text = GameLogic.Instance.timerMinutes.ToString() + ":" + secs; 
	}
}
