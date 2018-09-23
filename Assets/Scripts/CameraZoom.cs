using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    Vector3 pos;

    private void Start()
    {
        pos = transform.localPosition;
    }
    // Update is called once per frame
    void Update () {
        Debug.DrawRay(transform.parent.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.position+Vector3.up*0.01f, -transform.forward, out hit, pos.magnitude) && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().airborne)
        {   if (hit.collider.transform.root.name!="Phi") { 
                Vector3 hitLocalPos = hit.point - transform.parent.position;
                transform.localPosition = new Vector3(pos.x / (pos.magnitude / hitLocalPos.magnitude), (pos.y / (pos.magnitude / hitLocalPos.magnitude)) + (1-(hitLocalPos.magnitude / pos.magnitude)), pos.z / (pos.magnitude / hitLocalPos.magnitude));
            }
        } else
        {
            transform.localPosition = pos;
        }
	}
}
