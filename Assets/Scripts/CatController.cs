using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour {

	public float top_speed = 5f;
	bool facing_right = true;

	Animator catAnimator;
	Rigidbody2D rigidBody;
	bool grounded = false;

	public Transform ground_check;

	float ground_radius = 0.2f;
	public float jump_force = 750f;

	// What layer is ground
	public LayerMask WhatIsGround;

	public bool stopped;

	AudioSource meow;


	void Start() {
		catAnimator = GetComponent<Animator> ();
		stopped = false;
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if (stopped) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,  GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -50f));
			return;
		}
			
		grounded = Physics2D.OverlapCircle (ground_check.position, ground_radius, WhatIsGround);

		catAnimator.SetBool ("Ground", grounded);

		catAnimator.SetFloat ("vSpeed", rigidBody.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		rigidBody.velocity = new Vector2 (move * top_speed, rigidBody.velocity.y);

		catAnimator.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facing_right) {
			Flip ();
		} else if (move < 0 && facing_right) {
			Flip ();
		}

		Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		if (screenPos.y < -100f) {
			rigidBody.AddForce (new Vector2 (0, 1500f));
			rigidBody.freezeRotation = false;
			rigidBody.AddTorque(15f);

			foreach (CircleCollider2D c in GetComponents<CircleCollider2D> () ) {
				c.enabled = false;
			}
				
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponentInChildren<BoxCollider2D> ().enabled = false;
			GetComponent<PlatformEffector2D> ().enabled = false;
			Camera.main.GetComponent<CameraScript> ().gameOver = true;
			GetComponent<AudioSource>().Play();
			StartCoroutine (GameOverDelay ());

		}
	}

	void Update() {
		if (stopped) {
			return;
		}
			
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			catAnimator.SetBool ("Ground", false);
			rigidBody.AddForce(new Vector2(0, jump_force));
		}
	}

	void Flip() {
		facing_right = !facing_right;
		Vector3 the_scale = transform.localScale;

		the_scale.x *= -1;
		transform.localScale = the_scale;

	}

	IEnumerator GameOverDelay() {
		yield return StartCoroutine(GameOver(1.7f));
	}
		

	IEnumerator GameOver(float delay)
	{
		yield return new WaitForSeconds(delay);
		Debug.Log ("GAME OVER");
		SceneManager.LoadScene (2);
	}

}



