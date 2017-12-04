using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//0.02
//0.3333333
public class CameraScript : MonoBehaviour {
	public float waitTime = 3000f;
	float timer;

	/// <summary>
	/// The time taken to move from the start to finish positions
	/// </summary>
	public float timeTakenDuringLerp = 1f;

	/// <summary>
	/// How far the object should move when 'space' is pressed
	/// </summary>
	public float distanceToMove = 10;

	//Whether we are currently interpolating or not
	private bool _isLerping;

	//The start and finish positions for the interpolation
	private Vector3 _startPosition;
	private Vector3 _endPosition;

	private Vector3 _startPosition_craneAnchor;
	private Vector3 _endPosition_craneAnchor;
	GameObject craneAnchor;

	private Vector3 _startPosition_crane;
	private Vector3 _endPosition_crane;
	GameObject crane;

	private Vector3 _startPosition_tube;
	private Vector3 _endPosition_tube;
	GameObject tube;


	public Vector3 firstPosition;
	public bool startTimer;
	private float timeToSlide;
	public bool gameOver;
	public bool winState;
	private bool started;


	//The Time.time value when we started the interpolation
	private float _timeStartedLerping;

	void Start() {
		startTimer = false;
		winState = false;
		gameOver = false;
		started = false;
		timeToSlide = 15f;
		craneAnchor = GameObject.Find ("CraneAnchor");
		crane = GameObject.Find ("Crane");
		tube = GameObject.Find ("TubeDraw");
		firstPosition = gameObject.transform.position;
	}

	/// <summary>
	/// Called to begin the linear interpolation
	/// </summary>
	void StartLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = transform.position;
		//_endPosition = transform.position + Vector3.down*distanceToMove;
		_endPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

		_startPosition_craneAnchor = craneAnchor.transform.position;
		_endPosition_craneAnchor = new Vector3(craneAnchor.transform.position.x, craneAnchor.transform.position.y + 1f, craneAnchor.transform.position.z);

		_startPosition_crane = crane.transform.position;
		_endPosition_crane = new Vector3(crane.transform.position.x, crane.transform.position.y + 1f, crane.transform.position.z);

		_startPosition_tube = tube.transform.position;
		_endPosition_tube = new Vector3(tube.transform.position.x, tube.transform.position.y + 1f, tube.transform.position.z);




	}

	void Update()
	{
		if (startTimer && !started) {
			started = true;
			StartCoroutine (Slide ());
		}
		//		timer += Time.deltaTime;
		//		if (timer > waitTime) {
		//			Debug.Log ("Timer is done");

		//			//transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z), 0.5f*Time.deltaTime);
		//			timer = 0f;
		//		}

	}

	IEnumerator Slide() {
		Debug.Log ("Slide");
		while (!gameOver && !winState) {
			StartLerping ();
			yield return new WaitForSeconds (timeToSlide);
		} 
		yield return null;
	}

	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		if(_isLerping)
		{
			//We want percentage = 0.0 when Time.time = _timeStartedLerping
			//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
			//In other words, we want to know what percentage of "timeTakenDuringLerp" the value
			//"Time.time - _timeStartedLerping" is.
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			//Perform the actual lerping.  Notice that the first two parameters will always be the same
			//throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
			//to start another lerp)
			transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);
			craneAnchor.transform.position = Vector3.Lerp (_startPosition_craneAnchor, _endPosition_craneAnchor, percentageComplete);
			crane.transform.position = Vector3.Lerp (_startPosition_crane, _endPosition_crane, percentageComplete);
			tube.transform.position = Vector3.Lerp (_startPosition_tube, _endPosition_tube, percentageComplete);

			//When we've completed the lerp, we set _isLerping to false
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
			}
		}
	}

}
