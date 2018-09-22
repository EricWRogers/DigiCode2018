using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = GameLogic.Instance.startPos;
            transform.parent.position = GameLogic.Instance.enemyStartPos;
            transform.parent.GetComponent<EnemyAI>().foundPlayer = false;
            transform.parent.GetComponent<NavMeshAgent>().ResetPath();
            GameLogic.Instance.Drop();
        }
    }
}
