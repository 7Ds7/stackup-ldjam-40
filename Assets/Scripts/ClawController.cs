using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour {

	bool closing = false;
	GameObject drawShape;
	GameObject clawLeft;
	GameObject clawRight;
	// Use this for initialization
	void Start () {
		drawShape = GameObject.Find ("DrawShape");
		clawLeft = GameObject.Find("ClawLeft");
		clawRight = GameObject.Find("ClawRight");
	}

	// Update is called once per frame
	void Update () {
//		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
//		Debug.Log (hit.collider);
//		Debug.Log (hit.collider.tag);
//		if (hit.collider != null ) {
//			Debug.Log (hit.collider);
//		}




		if (Input.GetMouseButton (0) ) {
			closing = true;

			if (clawLeft.transform.rotation.z <= 0) {
				if (!clawLeft.GetComponent<ClawHit>().hit)
					clawLeft.transform.Rotate (clawLeft.transform.rotation.x, clawLeft.transform.rotation.y, clawLeft.transform.rotation.z + 1f);
				if (!clawRight.GetComponent<ClawHit>().hit)
					clawRight.transform.Rotate (clawRight.transform.rotation.x, clawRight.transform.rotation.y, clawRight.transform.rotation.z - 1f);
			}
			//clawLeft.transform.Rotate(0, 0, Time.deltaTime);
			//gameObject.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			if (clawLeft.transform.rotation.z > -0.34f )
				clawLeft.transform.Rotate (clawLeft.transform.rotation.x, clawLeft.transform.rotation.y, clawLeft.transform.rotation.z - 1f);
			if ( clawRight.transform.rotation.z < 0.34f)
				clawRight.transform.Rotate (clawRight.transform.rotation.x, clawRight.transform.rotation.y, clawRight.transform.rotation.z + 1f);

		}
		
		if (Input.GetMouseButtonUp (0)) {
			closing = false;
			Debug.Log ("closed");
			//gameObject.GetComponent<Renderer> ().material.color = Color.black;
		}
		
	}

	void OnTriggerStay2D(Collider2D col) {
		
		Debug.Log (col);
//		if (col.tag == "Shape" && closed == true) {
//			col.gameObject.GetComponent<PieceController> ().grabbed = true;
//		} else if (col.tag == "Shape" && closed == false) {
//			col.gameObject.GetComponent<PieceController> ().grabbed = false;
//
//		}

	}

		
}
