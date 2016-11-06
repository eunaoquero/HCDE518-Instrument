using UnityEngine;
using System.Collections;

public class moveBehavior : MonoBehaviour {

	private Vector3 initPos;
	public Vector3 endPos;

	private Vector3 initRot;
	public Vector3 endRot;


	//TODO:
	//should store pointer instead
	private Vector3 fromPos;
	private Vector3 toPos;
	private Vector3 fromRot;
	private Vector3 toRot;


	public float speed;
	private float startTime;
	private float posJourneyLength;
	private float rotJourneyLength;


	float fracPosJourney,fracRotJourney,distCovered;

	bool moving ;
	NavigationBehavior NB;



	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.localPosition;
		initRot = gameObject.transform.localRotation.eulerAngles;

		fracPosJourney = 1;
		fracRotJourney = 1;
		moving = false;

		NB = GameObject.Find("EventSystem").GetComponent<NavigationBehavior>();

	}
	
	// Update is called once per frame
	void Update () {
	

		if (moving) {
			distCovered = (Time.time - startTime) * speed;

			fracPosJourney = distCovered / posJourneyLength;
			transform.localPosition = Vector3.Lerp (fromPos, toPos, fracPosJourney);

			fracRotJourney = distCovered * 20 / rotJourneyLength;
			transform.eulerAngles = Vector3.Lerp (fromRot, toRot, fracRotJourney);

				if (fracPosJourney > 1) {
				NB.movingState (false);
					moving = false;
				}
		

		}
	}


	public bool foward(){


		if (!moving) {

			NB.movingState (true);

			startTime = Time.time;

			fromPos = initPos;
			fromRot = initRot;
			toPos = endPos;
			toRot = endRot;

			moving = true;

			Debug.Log ("forward called " + transform.name);

			posJourneyLength = Vector3.Distance (fromPos, toPos);
			rotJourneyLength = Vector3.Distance (fromRot, toRot);

			return true;
		}

		return false;
	}


	public bool backwards(){


		if (!moving) {

			NB.movingState (true);


			fromPos = endPos;
			fromRot = endRot;
			toPos = initPos;
			toRot = initRot;


			moving = true;

			startTime = Time.time;

			Debug.Log ("backwards called" + transform.name);

			posJourneyLength = Vector3.Distance (toPos, fromPos);
			rotJourneyLength = Vector3.Distance (toRot, fromRot);

			return true;
		}

		return false;
	}

}
