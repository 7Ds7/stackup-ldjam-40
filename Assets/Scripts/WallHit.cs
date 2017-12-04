using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour {

	CatController ccontroller;
	// Use this for initialization
	void Start () {
		ccontroller = GameObject.Find ("Cat").GetComponent<CatController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D() {
		ccontroller.stopped = true;
	}

	void OnCollisionStay2D() {
		ccontroller.stopped = false;
	}

	void OnCollisionExit2D() {
		ccontroller.stopped = false;
	}
}
