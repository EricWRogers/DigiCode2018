using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController ctrl;
	Animator anim;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 1f;

    public bool airborne;

    public Vector3 startPos;
    public float upVelocity;

	void Start () {
        ctrl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
        startPos = transform.position;
    }
	
	void Update () {
        if (GameLogic.Instance.mainCanvas.gameObject.activeInHierarchy && !airborne)
        {
            ctrl.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed);
		    anim.SetFloat("forwardVelocity", ctrl.velocity.magnitude);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0));
		    anim.SetFloat("turnVelocity", ctrl.velocity.y);
        }
        if (airborne)
        {
            ctrl.Move((startPos-transform.position)*Time.deltaTime);
            ctrl.Move(new Vector3(0, upVelocity * Time.deltaTime, 0));
            upVelocity += Physics.gravity.y * Time.deltaTime;
            if (upVelocity < 0) { upVelocity += Physics.gravity.y * Time.deltaTime; }
            if (Vector3.Distance(startPos - new Vector3(0, startPos.y, 0), transform.position - new Vector3(0, transform.position.y, 0)) < 1f) { upVelocity += Physics.gravity.y * Time.deltaTime; }
            Debug.Log(upVelocity);
            if (ctrl.isGrounded)
            {
                airborne = false;
            }
        }
	}
}
