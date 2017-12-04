using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			Destroy (coll.gameObject);
		}
	}
}
