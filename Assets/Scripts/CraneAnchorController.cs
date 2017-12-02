using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneAnchorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Input.mousePosition;
		Debug.Log (pos.y);
		pos = Camera.main.ScreenToWorldPoint(pos);
		transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);

	}
}
