using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour {

    // Use this for initialization
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().slow = true;
            other.GetComponent<PlayerMovement>().slowTime = 1f;
        }
    }
}
