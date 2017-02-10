using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	public static GM instance = null;

	//Meter Values
	public Text movementMeter;
	public Text soundMeter;
	public Text visionMeter;
	public Text lightMeter;

//	public GameObject MovementMeter;
	public MovementMeter mMeter;
	public float mValue;
	public bool mSwitch = true;

	//Movement Variables
	public GameObject movementMed;
	public float movementMeterValue = 100;
	public float decrementMovement = 1;
	public float incrementMovement = 25;
	public bool invertMovement = false;
	//develop a timer that will tic every x seconds, decrease the movement meter


	public bool hidden = false;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mSwitch == true) {
			//MOVEMET TICK WILL ONLY START ONCE ACTIVE
			Debug.Log("IM TRUE");
			mMeter.gameObject.SetActive (true);
		}


//		mValue = mMeter.movementReturnValue ();
//		Debug.Log (mValue);
//
//		movementMeter.text = "Movement: " + mValue;
	}




	//---------------------------------HIDE CODE---------------------------------------
	public void playerHidden() {
		hidden = true;
		mSwitch = true;

	}
	public void playerNotHidden() {
		hidden = false;
	}
	public bool hiddenCheck() {
		return hidden;
	}

	//---------------------------------MEDICINE CODE---------------------------------------
	//MEDICINE UI
	public void displayMoveMed() {
		movementMed.SetActive (true);
	}
	public void hideMoveMed() {
		movementMed.SetActive (false);
	}

	//MEDICINE FUNCTIONALITY
	public void onTakeMoveMed() {
		movementMeterValue += incrementMovement;
	}
	public void decreaseMovement() {
		movementMeterValue -= decrementMovement;
	}

}
