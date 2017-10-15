using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	// externally modifiable variables to controll the player's physics.
	public int speed;
	public int jumpHeight;

	// player motion
	private Vector2 movement;
	private Vector2 jump;
	private Rigidbody2D rigidbodyComponent;

	private bool jumping;

	// animation
	Animator anim;
	SpriteRenderer sprtRend;

	// initialization
	void Start () {
		jumping = false;
		anim = GetComponent<Animator> ();
		rigidbodyComponent = GetComponent<Rigidbody2D> ();
		sprtRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		// update the player animation based on the keyboard input.
		if(jumping && Input.GetKey (KeyCode.Space)) {
			anim.SetInteger ("State", 2);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {

			// as per the sprite sheet, the sprite is not flipped when facing left.
			if (sprtRend.flipX)
				sprtRend.flipX = false;

			anim.SetInteger ("State", 1);

		} else if (Input.GetKey (KeyCode.RightArrow)) {

			// the sprite is "flipped" when facing right.
			if (!sprtRend.flipX)
				sprtRend.flipX = true;
			
			anim.SetInteger ("State", 1);
		} else {
			anim.SetInteger ("State", 0);
		}
	}

	void FixedUpdate() {
		
		// move the player via the rigidbody according to inputs on the arrow keys.
		movement = new Vector2 (Input.GetAxis ("Horizontal") * speed, rigidbodyComponent.velocity.y);
		rigidbodyComponent.velocity = movement;

		// jump when the player hits the spacebar.
		if (!jumping && Input.GetKeyDown (KeyCode.Space)) {
			// make sure the player can't jump again until they've hit the ground.
			jumping = true;

			// add the jump to the player movement.
			jump = new Vector2(0, jumpHeight);
			rigidbodyComponent.AddForce (jump, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// don't allow the player to jump again until they've hit the ground.
		if (coll.gameObject.tag == "Ground") {
			jumping = false;
		}
	}
}
