using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {
	public static GM instance = null;

	//Movement Variables
	public GameObject movementMed;
	public float movementMeter = 100;
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
	
	}




	//---------------------------------HIDE CODE---------------------------------------
	public void playerHidden() {
		hidden = true;
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
		movementMeter += incrementMovement;
	}
	public void decreaseMovement() {
		movementMeter -= decrementMovement;
	}

}
