using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHit : MonoBehaviour {

	public bool hit = false;

	void OnCollisionEnter2D(Collision2D coll) {
		float y_coll = Camera.main.ScreenToWorldPoint (coll.gameObject.transform.position).y;
		float y_claw = Camera.main.ScreenToWorldPoint (gameObject.transform.position).y;

		if (coll.gameObject.tag == "Shape" && y_claw > y_coll) {
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

//	void OnDrawGizmos() {
//		Gizmos.color = Color.white;
//		Gizmos.DrawWireCube (GetComponent<PolygonCollider2D> ().bounds.center, GetComponent<PolygonCollider2D> ().bounds.size);
//	}
}
