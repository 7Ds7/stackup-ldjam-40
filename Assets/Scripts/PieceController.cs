using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

	public bool grabbed;
	// Use this for initialization

	public bool gLeft;
	public bool gRight;

	private bool wasVisible;
	void Start () {
		grabbed = false;
		wasVisible = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (gLeft && gRight) {
			transform.SetParent(GameObject.Find("CraneClaw").transform);
		}

		if (!gLeft && !gRight) {
			transform.parent = null;
		}

		if ( gameObject.GetComponent<SpriteRenderer> ().isVisible) {
			Debug.Log("Is Visible");
			wasVisible = true;
		}

		if (!I_Can_See() && wasVisible) {
			//gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			Debug.Log ("Set some to kinema");
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;

			gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;

		}

			
//		if (grabbed) {
//			transform.localPosition = GameObject.Find("Claw").transform.localPosition;
//		}
	}



	void FixedUpdate () {
		if (gameObject.GetComponent<Rigidbody2D> ().freezeRotation) {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		}
	}

	private bool I_Can_See() {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (Camera.main);

		if (GeometryUtility.TestPlanesAABB (planes, gameObject.GetComponent<SpriteRenderer>().bounds))
			return true;
		else
			return false;
	}

	private bool IsTargetVisible(Camera c,GameObject go)
	{
		var planes = GeometryUtility.CalculateFrustumPlanes(c);
		var point = go.transform.position;
		foreach (var plane in planes)
		{
			if (plane.GetDistanceToPoint(point) < 0)
				return false;
		}
		return true;
	}


}
