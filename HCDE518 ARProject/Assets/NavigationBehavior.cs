using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NavigationBehavior : MonoBehaviour {
	public GameObject[] Pieces;


	private int currentPiece;
	private bool begin, end, busy;
	public Button OBJbanner;


	// Use this for initialization
	void Start () {
		currentPiece = 0;

		begin = true;
		end = false;
		busy = false;

		updateBanner ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void next(){

		if (!busy && !end && ((currentPiece < Pieces.Length))  ) {
			if (Pieces [currentPiece].GetComponent<moveBehavior> ().foward ()) {
				begin = false;
				//hack to avoid overflow
				if (currentPiece < Pieces.Length) {
					currentPiece++;
					updateBanner ();
				} else {
					end = true;
				}

			}



		}

		Debug.Log ("next called");

	}


	public void previous(){

		if ( !busy && !begin   && (currentPiece -1 >= 0)   ) {
			if (Pieces [currentPiece -1 ].GetComponent<moveBehavior> ().backwards ()) {
			end = false;
				currentPiece--;
				updateBanner ();
			}


		}


		Debug.Log ("previous called");

	}


	public void PlayScene(int scene){

		Application.LoadLevel(scene);


	}


	public bool movingState( bool TMPbusy ){

		if ( TMPbusy && !busy ) {

			busy = true;
			return true;
		}

		if (TMPbusy == false) {

			busy = false;
			return true;
		}

		return false;
	}



	private void updateBanner(){

		OBJbanner.GetComponentInChildren<Text> ().text = (currentPiece).ToString();

	}



}
