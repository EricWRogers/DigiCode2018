using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public GameObject statue;
	
	void Update () {
        statue.transform.localPosition = Vector3.Lerp(startPos, endPos, (float)GameLogic.Instance.currentCollected / (float)GameLogic.Instance.collectedNeeded);
    }
}
