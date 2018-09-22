using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController ctrl;
	Animator anim;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 1f;

	void Start () {
        ctrl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (GameLogic.Instance.mainCanvas.gameObject.activeInHierarchy)
        {
            ctrl.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed);
		    anim.SetFloat("forwardVelocity", ctrl.velocity.magnitude);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0));
		    anim.SetFloat("turnVelocity", ctrl.velocity.y);
        }
	}
}
