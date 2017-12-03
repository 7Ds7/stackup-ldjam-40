using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	public float top_speed = 5f;
	bool facing_right = true;

	Animator catAnimator;

	bool grounded = false;

	public Transform ground_check;

	float ground_radius = 0.2f;
	public float jump_force = 700f;

	// What layer is ground
	public LayerMask WhatIsGround;

	void Start() {
		catAnimator = GetComponent<Animator> ();

	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (ground_check.position, ground_radius, WhatIsGround);

		catAnimator.SetBool ("Ground", grounded);

		catAnimator.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * top_speed, GetComponent<Rigidbody2D> ().velocity.y);

		catAnimator.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facing_right) {
			Flip ();
		} else if (move < 0 && facing_right) {
			Flip ();
		}
	}

	void Update() {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			catAnimator.SetBool ("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_force));
		}
	}

	void Flip() {
		facing_right = !facing_right;
		Vector3 the_scale = transform.localScale;

		the_scale.x *= -1;
		transform.localScale = the_scale;

	}

}



