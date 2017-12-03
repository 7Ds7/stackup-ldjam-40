using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

	public bool grabbed;
	// Use this for initialization
	void Start () {
		grabbed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (grabbed) {
			transform.localPosition = GameObject.Find("Claw").transform.localPosition;
		}
	}
}
