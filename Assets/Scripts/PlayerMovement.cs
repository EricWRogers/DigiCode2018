using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController ctrl;

	void Start () {
        ctrl = GetComponent<CharacterController>();
	}
	
	void Update () {
        ctrl.Move(transform.forward*Input.GetAxis("Vertical")*0.1f);
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));
	}
}
