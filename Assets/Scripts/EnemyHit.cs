using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().airborne = true;
            other.GetComponent<PlayerMovement>().upVelocity = 50f+Mathf.Sqrt((other.GetComponent<PlayerMovement>().startPos-other.transform.position).magnitude);
            transform.parent.position = GameLogic.Instance.enemyStartPos;
            transform.parent.GetComponent<EnemyAI>().foundPlayer = false;
            transform.parent.GetComponent<NavMeshAgent>().ResetPath();
            GameLogic.Instance.Drop();
        }
    }
}
