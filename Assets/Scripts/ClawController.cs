using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour {

	bool closed = false;
	GameObject drawShape;
	// Use this for initialization
	void Start () {
		drawShape = GameObject.Find ("DrawShape");
	}

	// Update is called once per frame
	void Update () {
//		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
//		Debug.Log (hit.collider);
//		Debug.Log (hit.collider.tag);
//		if (hit.collider != null ) {
//			Debug.Log (hit.collider);
//		}
	
		if (Input.GetMouseButtonDown (0)) {
			closed = true;
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
		
		if (Input.GetMouseButtonUp (0)) {
			closed = false;
			Debug.Log ("closed");
			gameObject.GetComponent<Renderer> ().material.color = Color.black;
		}
		
	}

	void OnTriggerStay2D(Collider2D col) {
		Debug.Log (col);
		if (col.tag == "Shape" && closed == true) {
			col.gameObject.GetComponent<PieceController> ().grabbed = true;
		} else if (col.tag == "Shape" && closed == false) {
			col.gameObject.GetComponent<PieceController> ().grabbed = false;

		}

	}

		
}
