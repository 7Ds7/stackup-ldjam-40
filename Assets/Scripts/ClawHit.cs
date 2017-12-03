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
		hit = true;
	}

	void OnCollisionExit2D(Collision2D coll) {
		hit = false;
	}
}
