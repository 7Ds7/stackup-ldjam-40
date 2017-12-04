using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

	public bool grabbed;
	// Use this for initialization

	public bool gLeft;
	public bool gRight;

	private bool wasVisible;
	void Start () {
		grabbed = false;
		wasVisible = false;
	}

	// Update is called once per frame
	void Update () {
		
		
		if (gLeft && gRight) {
			transform.SetParent(GameObject.Find("CraneClaw").transform);
		}

		if (!gLeft && !gRight) {
			transform.parent = null;
		}


	}



	void FixedUpdate () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//Debug.Log("target is " + screenPos.y + " pixels from the left");

		if (screenPos.y < -100f) {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		}

		if (screenPos.y < -1000f) {
			Destroy (gameObject);
		}
	}


}
