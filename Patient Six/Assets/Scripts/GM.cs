using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	public static GM instance = null;

	public GameObject startGame;

	public GameObject playerPrefab;
	public GameObject robotPrefab;
	//Player and Robot objects
	private GameObject clonePlayer;
	private GameObject cloneRobot;
	private Vector3 playerPosition = new Vector3 (27.0f, 1.11f, -20f);
	private Vector3 robotPosition = new Vector3 (17f, 1f, 2f);
	public bool playerDarted;

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

	//UI ELEMENTS: CLIPBOARD
	public Image clipBoard;
	private bool isShowing;

	public bool hidden = false;

	void Awake() {
//		clonePlayer = Instantiate (playerPrefab, playerPosition, Quaternion.identity) as GameObject;

		if (instance == null) {
			instance = this;

		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		startTheGame ();
	}
	void startTheGame() {
		Time.timeScale = 0.0f;
		startGame.SetActive (true);
	}
	void Setup() {
		Time.timeScale = 1.0f;
		startGame.SetActive (false);
		//Instantiate player and Robot

//		cloneRobot = Instantiate (robotPrefab, robotPosition, Quaternion.identity) as GameObject;
	}
	void Reset() {
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void dartReset() {
		//pause the scene, move the player to his bed, deduct 50% meters
		Time.timeScale = 0.25f;
		float fadeTime = GameObject.Find ("GM").GetComponent<Fading> ().BeginFade (1);
		Invoke ("replacePlayer", 1.0f);
		replaceRobot ();
	}
	void replacePlayer() {
		Time.timeScale = 1f;
		float fadeTime = GameObject.Find ("GM").GetComponent<Fading> ().BeginFade (-1);
		playerPrefab.transform.position = playerPosition;

	}
	void replaceRobot() {
		//change inSight to false
		//reposition him 
//		robotPrefab.gameObject.GetComponent<RobotMovement>().toggleInSight();
		hidden = true;
	}

	// Update is called once per frame
	void Update () {
		//starting the game
		if (startGame == true) {

		}
		if (Input.GetKeyDown ("s")) {
			Setup ();
		}
		if (Input.GetKeyDown ("r")) {
//			Reset ();
		}

		if (playerDarted == true) {
			dartReset ();
//			Invoke ("dartReset", 1.0f);
			playerDarted = false;
		}

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
	public void displayClipBoard() {
		isShowing = !isShowing;
		clipBoard.gameObject.SetActive (isShowing);
	}
	public void hideClipBoard() {
		clipBoard.gameObject.SetActive (false);
	}
	//MEDICINE FUNCTIONALITY
	public void onTakeMoveMed() {
		movementMeterValue += incrementMovement;
	}
	public void decreaseMovement() {
		movementMeterValue -= decrementMovement;
	}

	//---------------------------------DART CODE---------------------------------------
	public void dartPlayer() {
		Time.timeScale = 0.25f;
		//SLOW DOWN MOUSE MOVEMENT ASWELL
		playerDarted = true;

	}
}
