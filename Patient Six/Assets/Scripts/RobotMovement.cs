using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour {
	public Transform[] path;
	public float speed = 1.0f;
	public float speedRotate = 1.0f;
	public float reachDist = 10.0f;
	public int currentPoint = 0;

	public bool inSight = false;
	public bool hiddenChecker = false;
	public bool wait = false;
	public bool readyToMove = true;
	public bool readyToRotate = true;
	public bool investigate = false;
	public float distanceToSee = 5.0f;

	public Transform target;
	public Transform myTransform;
	public Transform targetPath;

	public Quaternion newRot;
	public Vector3 currRot;
	public Vector3 distance;
	public float minAngle = -45f;
	public float maxAngle = 45f;
//	Quaternion rotI = new Quaternion(0f, 30f, 0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.red);
		if (inSight == true) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward * 1 * Time.deltaTime);
		}

		if (inSight == false && wait == true) {
			
		}
		if (inSight == false) {
			
			float dist = Vector3.Distance (path [currentPoint].position, transform.position);

			//ROTATE BEFORE MOVE....WORKS-------
			if (readyToMove == true && wait == false) {
				transform.position = Vector3.Lerp (transform.position, path [currentPoint].position, Time.deltaTime * speed);
			}
//			rotate ();
			//---------------------------


			if (investigate == false) {
					rotate ();

			}

		


			if (dist <= reachDist) {
				wait = true;
				investigate = true;

				Debug.Log (path [currentPoint]);
				currentPoint++;
				//THIS WORKS FOR WAITING 8 SECONDS AT EACH POSITION
				Invoke ("waitCycle", 6.0f);
				Invoke ("investigateCycle", 3.0f);
//				Invoke ("rotateCycleTrue", 7.0f);
//				Invoke ("rotateCycleFalse", 9.0f);


				Invoke ("moveCycle", 8.0f);
				Debug.Log ("REACHED POSITION");
				readyToMove = false;
//				Invoke ("moveCycle", 10.0f);
			}

			if (currentPoint >= path.Length) {
				currentPoint = 0;
			}

		}

		if (wait == true) {

			if (investigate == true) {
				Debug.Log ("INVESTIGATING");
				if (path [currentPoint].name == "Destination2" || path[currentPoint].name == "Destination5") {
					transform.rotation = Quaternion.Euler (0f, transform.rotation.eulerAngles.y + 1 * Mathf.Sin (Time.time * 1), 0f);
				} else {
//					transform.rotation = Quaternion.Euler (0f, transform.rotation.eulerAngles.y + 1 * Mathf.Sin (Time.time * 1), 0f);

				}
//
//				transform.rotation = Quaternion.Euler (0f, transform.rotation.eulerAngles.y + 1 * Mathf.Sin (Time.time * 1), 0f);


//				transform.rotation = Quaternion.Euler (0f, transform.rotation.eulerAngles.y + 1 * Mathf.Sin (Time.time * 1), 0f);
//				investigate = false;
//				Invoke ("investigateCycle", 2.0f);


			} 

		}

		hiddenChecker = GM.instance.hiddenCheck ();
		if (hiddenChecker == true) {
			inSight = false;
		}

	}


	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Player") {
			inSight = true;
		}
	}

	void incrementPoint() {
		currentPoint++;
	}
	void waitCycle() {
		wait = false;
	}
			
	void onDrawGizmos() {
		if (path.Length > 0)
			for (int i = 0; i < path.Length; i++) {
				if (path [i] != null) {
					Gizmos.DrawSphere (path [i].position, reachDist);
				}
			}
	}

	void rotate() {
		Debug.Log ("Rotate to next point");
		distance = path [currentPoint].position - transform.position;
		newRot = Quaternion.LookRotation (distance, transform.up);
		newRot.x = 0;
		newRot.z = 0;
		transform.rotation = Quaternion.Lerp (transform.rotation, newRot, speedRotate * Time.deltaTime);
//		if (transform.rotation == newRot) {
		if (transform.rotation == newRot) {
			
//			readyToMove = true;
//			Invoke ("moveCycle", 1.0f);
		}

		Invoke ("moveCycle", 5.0f);
	}

	void moveCycle() {
		readyToMove = true;
	}

	void investigateCycle() {
		investigate = false;
		readyToRotate = true;
	}
	void investigateCycleTrue() {
		investigate = true;
	}
	void rotateCycleTrue() {
		readyToRotate = true;
	}
	void rotateCycleFalse() {
		readyToRotate = false;
	}
}
