using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    NavMeshAgent ag;
    public bool foundPlayer;
    float xWander, zWander;
    public float angle, range;
    GameObject plr;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        ag = GetComponent<NavMeshAgent>();
        plr = GameObject.FindGameObjectWithTag("Player");

	}
	
	void Update () {
        anim.SetFloat("forwardVelocity", ag.velocity.magnitude);
        anim.SetFloat("turnVelocity", ag.velocity.y);
        if (!foundPlayer)
        {
            if (!ag.hasPath || ag.remainingDistance < 1f)
            {
                xWander += Random.Range(0f, range);
                if (xWander > range) { xWander -= range * 2f; }
                zWander += Random.Range(0f, range);
                if (zWander > range) { zWander -= range * 2f; }
                ag.SetDestination(new Vector3(xWander, 0, zWander));
            }
            if (Vector3.Angle(transform.forward, plr.transform.position - transform.position) < angle)
            {
                RaycastHit hit;
                Ray r = new Ray(transform.position, plr.transform.position - transform.position);

                if (Physics.Raycast(r, out hit, Mathf.Infinity))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        foundPlayer = true;
                    }
                }
            }
        } else
        {
            ag.SetDestination(plr.transform.position);
        }
        
	}
}
