using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController ctrl;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 1f;

	void Start () {
        ctrl = GetComponent<CharacterController>();
	}
	
	void Update () {
        if (GameLogic.Instance.mainCanvas.gameObject.activeInHierarchy)
        {
            ctrl.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0));
        }
	}
}
