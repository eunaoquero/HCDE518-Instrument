using UnityEngine;
using System.Collections;

public class lerptest : MonoBehaviour {

	private Vector3 initPos;
	public Vector3 endPos;

	private Vector3 initRot;
	public Vector3 endRot;

	public float speed ;
	private float startTime;
	private float posJourneyLength;
	private float rotJourneyLength;

	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.localPosition;
		initRot = gameObject.transform.localRotation.eulerAngles;

		endPos = initPos;
		endRot = initRot;


	}
	
	// Update is called once per frame
	void Update () {
	
		float distCovered = (Time.time - startTime) * speed;


		float fracPosJourney = distCovered / posJourneyLength;
		transform.localPosition = Vector3.Lerp(initPos, endPos, fracPosJourney);

		float fracRotJourney = distCovered*20 / rotJourneyLength;
		transform.eulerAngles = Vector3.Lerp (initRot, endRot, fracRotJourney);
	}


	public void foward(){

		startTime = Time.time;
		posJourneyLength = Vector3.Distance(initPos, endPos);

		rotJourneyLength = Vector3.Distance (initRot, endRot);



	}


	public void backwards(){

		startTime = Time.time;
		posJourneyLength = Vector3.Distance(endPos, initPos);

		rotJourneyLength = Vector3.Distance (endRot, initRot);



	}

}
