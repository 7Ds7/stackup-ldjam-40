using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

	public bool grabbed;
	// Use this for initialization

	public bool gLeft;
	public bool gRight;
	void Start () {
		grabbed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gLeft && gRight) {
			transform.SetParent(GameObject.Find("CraneClaw").transform);
		}

		if (!gLeft && !gRight) {
			transform.parent = null;
		}
			
//		if (grabbed) {
//			transform.localPosition = GameObject.Find("Claw").transform.localPosition;
//		}
	}
}
