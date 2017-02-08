using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour {
	public Transform[] path;
	public float speed = 1.0f;
	public float reachDist = 10.0f;
	public int currentPoint = 0;

	public bool inSight = false;
	public bool hiddenChecker = false;
	public bool wait = false;
	public float distanceToSee = 5.0f;

	public Transform target;
	public Transform myTransform;
	public Transform targetPath;

	Vector3 rot1 = new Vector3 (0, -45, 0);
	Vector3 rot2 = new Vector3 (0, 45, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.red);
		if (inSight == true) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward * 5 * Time.deltaTime);
		}


		if (inSight == false && wait == false) {

			float dist = Vector3.Distance (path [currentPoint].position, transform.position);

//			transform.LookAt(transform.position + movement, Vector3(0,0,1));
			transform.LookAt(path[currentPoint].transform);

			transform.position = Vector3.Lerp (transform.position, path [currentPoint].position, Time.deltaTime * speed);



			if (dist <= reachDist) {
				wait = true;
				currentPoint++;
				Invoke ("waitCycle", 3.0f);
				Debug.Log ("REACHED POSITION");
			}

			if (currentPoint >= path.Length) {
				currentPoint = 0;
			}

		}

		if (wait == true) {
			//Look back a forth
//			transform.Rotate (Vector3.up, 
//			transform.rotation = Quaternion.Lerp (transform.rotation, transform.rotation, Time.deltaTime * speed);
//			transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.position + rot2); 
//			transform.Rotate(Vector3.up, 20 * Time.deltaTime);
			transform.rotation = Quaternion.Euler(0f, transform.rotation.y + 15 * Mathf.Sin(Time.time * 2), 0f);

			Debug.Log (transform.rotation.y);
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
}
