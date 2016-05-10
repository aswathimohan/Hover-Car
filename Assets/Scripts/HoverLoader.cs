﻿using UnityEngine;
using System.Collections;

public class HoverLoader : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;

	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidBody;


	void Awake () {
		carRigidBody = GetComponent <Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	
	}

	void FixedUpdate(){
		Ray ray = new Ray (transform.position, transform.up);
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit, hoverHeight)){
			float propotionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * propotionalHeight * hoverHeight;
			carRigidBody.AddForce (appliedHoverForce, ForceMode.Acceleration);
		}

		carRigidBody.AddRelativeForce (0f, 0f, powerInput * speed);
		carRigidBody.AddRelativeTorque (0f, turnInput * turnSpeed, 0f);
	}
}
