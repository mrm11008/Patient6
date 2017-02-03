using UnityEngine;
using System.Collections;

public class playerRayCasting : MonoBehaviour {

	public float distanceToSee;
	RaycastHit whatIHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.blue);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {
			Debug.Log ("I touched something" + whatIHit.collider.gameObject.name);
		}
	}
}
