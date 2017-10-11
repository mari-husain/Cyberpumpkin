using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	public int speed;
	public int jumpHeight;

	private Vector2 movement;
	private Vector2 jump;
	private Rigidbody2D rigidbodyComponent;

	private bool canJump = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		// get the player's rigidbody component.
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// move the player via the rigidbody.
		movement = new Vector2 (Input.GetAxis ("Horizontal") * speed, rigidbodyComponent.velocity.y);
		rigidbodyComponent.velocity = movement;

		// jump when the player hits the spacebar.
		if (canJump && Input.GetKeyDown (KeyCode.Space)) {
			// make sure the player can't jump again until they've hit the ground.
			canJump = false;

			// add the jump to the player movement.
			jump = new Vector2(0, jumpHeight);
			rigidbodyComponent.AddForce (jump, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// don't allow the player to jump again until they've hit the ground.
		if (coll.gameObject.tag == "Ground") {
			canJump = true;
		}
	}
}
