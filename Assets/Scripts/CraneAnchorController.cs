using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneAnchorController : MonoBehaviour {

	Tentacle tentacle;

	// Use this for initialization
	void Start () {
		tentacle = gameObject.GetComponent<Tentacle>();
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint(pos);
		transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);

		int int_y = (int) pos.y;
		Debug.Log (int_y);
		switch (int_y)
		{
		case 5:
			tentacle._setting.length = 0.1f;
			break;
		case 4:
			tentacle._setting.length = 0.2f;
			break;
		case 3:
			tentacle._setting.length = 0.3f;
			break;
		case 2:
			tentacle._setting.length = 0.4f;
			break;
		case 1:
			tentacle._setting.length = 0.5f;
			break;
		case 0:
			tentacle._setting.length = 0.6f;
			break;
		case -1:
			tentacle._setting.length = 0.7f;
			break;
		case -2:
			tentacle._setting.length = 0.8f;
			break;
		case -3:
			tentacle._setting.length = 0.9f;
			break;
		case -4:
			tentacle._setting.length = 1f;
			break;
		case -5:
			tentacle._setting.length = 1.1f;
			break;
		default:
			print ("Incorrect intelligence level.");
			break;
		}


	}
}
