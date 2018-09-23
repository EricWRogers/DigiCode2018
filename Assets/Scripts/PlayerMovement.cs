using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController ctrl;
	Animator anim;
    float moveSpeed = 0.1f;
    public float slowMoveSpeed = 0.05f;
    public float normMoveSpeed = 0.2f;
    public float rotateSpeed = 1f;

    public bool airborne, airJump;

    public Vector3 startPos;
    public float defaultUpVelocity = 3.0f;
    public float upVelocity = 3.0f;
    
    public bool slow = false;
    public float slowTime = 0f;

	void Start () {
        ctrl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
        startPos = transform.position;
    }
	
	void Update () {
        if (slow)
        {
            moveSpeed = slowMoveSpeed;
            slowTime -= Time.deltaTime;
            if (slowTime <= 0f)
            {
                slow = false;
            }
        } else
        {
            moveSpeed = normMoveSpeed;
        }
        if (GameLogic.Instance.mainCanvas.gameObject.activeInHierarchy && !airborne)
        {
            ctrl.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed);
		    anim.SetFloat("forwardVelocity", ctrl.velocity.magnitude);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0));
		    anim.SetFloat("turnVelocity", ctrl.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&!airborne && !airJump)
        {
            upVelocity = defaultUpVelocity;
            airJump = true;
        }
        if (airborne || airJump)
        {
            if (airborne)
            {
                ctrl.Move((startPos - transform.position) * Time.deltaTime);
            }
            ctrl.Move(new Vector3(0, upVelocity * Time.deltaTime, 0));
            upVelocity += Physics.gravity.y * Time.deltaTime;
            if (upVelocity < 0) { upVelocity += Physics.gravity.y * Time.deltaTime; }
            if (Vector3.Distance(startPos - new Vector3(0, startPos.y, 0), transform.position - new Vector3(0, transform.position.y, 0)) < 1f) { upVelocity += Physics.gravity.y * Time.deltaTime; }
            if (ctrl.isGrounded)
            {
                airborne = false;
                airJump = false;
            }
        }
	}
}
