using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHit : MonoBehaviour {

	public bool hit = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			hit = true;
			if (gameObject.name == "ClawLeft")
				coll.gameObject.GetComponent<PieceController> ().gLeft = true;
			if (gameObject.name == "ClawRight")
				coll.gameObject.GetComponent<PieceController> ().gRight = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			hit = false;
			if (gameObject.name == "ClawLeft")
				coll.gameObject.GetComponent<PieceController> ().gLeft = false;
			if (gameObject.name == "ClawRight")
				coll.gameObject.GetComponent<PieceController> ().gRight= false;
		}
	}
}
