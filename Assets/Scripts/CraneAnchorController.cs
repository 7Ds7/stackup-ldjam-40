using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneAnchorController : MonoBehaviour {

	Tentacle tentacle;
	LineRenderer lineRenderer;
	GameObject claw;
	// Use this for initialization
	void Start () {
		tentacle = gameObject.GetComponent<Tentacle>();
		lineRenderer = GetComponent<LineRenderer> ();
		claw = GameObject.Find ("CraneClaw");
//		Renderer MyRenderer = gameObject.GetComponent<Renderer>();
//		MyRenderer.sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint(pos);

		//transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z).Lerp;

		//transform.position = Vector3.Lerp (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3 (pos.x, transform.position.y, 0f), 0.5f * Time.deltaTime);

		if (pos.x < 8.5f && pos.x > -8.5f)
			transform.position = new Vector3 (pos.x, transform.position.y, -1f);
		else if (pos.x < 8.5f) {
			transform.position = new Vector3 (-8.5f, transform.position.y, -1f);
		} else if (pos.x > -8.5f) {
			transform.position = new Vector3 (8.5f, transform.position.y, -1f);
		}

		Vector3 posfin = lineRenderer.GetPosition (lineRenderer.positionCount - 1);
		claw.transform.position = new Vector3 (posfin.x - 0.25f, posfin.y - 0.2f, -1f);

		if ( pos.y <= 4f && pos.y >= -2f)
			tentacle._setting.length = ((pos.y - 5) * 1) / (-3 - 5) ;

		// NO SLEEP LEADS TO THE FOLLOWING
		//int int_y = (int) pos.y;

//		switch (int_y)
//		{
//		case 5:
//			tentacle._setting.length = 0.2f;
//			break;
//		case 4:
//			tentacle._setting.length = 0.3f;
//			break;
//		case 3:
//			tentacle._setting.length = 0.4f;
//			break;
//		case 2:
//			tentacle._setting.length = 0.5f;
//			break;
//		case 1:
//			tentacle._setting.length = 0.6f;
//			break;
//		case 0:
//			tentacle._setting.length = 0.7f;
//			break;
//		case -1:
//			tentacle._setting.length = 0.8f;
//			break;
//		case -2:
//			tentacle._setting.length = 0.9f;
//			break;
//		case -3:
//			tentacle._setting.length = 1f;
//			break;
////		case -4:
////			tentacle._setting.length = 1f;
////			break;
////		case -5:
////			tentacle._setting.length = 1.1f;
////			break;
//		default:
////			Debug.Log ("bamm");
////			Debug.Log (int_y);
//			break;
//		}


	}
}
