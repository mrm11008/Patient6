using UnityEngine;
using System.Collections;

public class playerRayCasting : MonoBehaviour {

	public float distanceToSee;
	RaycastHit whatIHit;
	private bool touching = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.blue);
		touching = false;
		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {
			touching = true;
			Debug.Log (whatIHit.collider.tag);
//			if (whatIHit.collider.tag == null) {
//				GM.instance.hideMoveMed ();
//			}
			if (whatIHit.collider.tag == "MoveMed") {
				GM.instance.displayMoveMed ();

			} else {
				GM.instance.hideMoveMed ();


			} 

		
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("I picked up a " + whatIHit.collider.gameObject.name);
				if (whatIHit.collider.tag == "MoveMed") {
					

					Debug.Log ("WTF");
					if (whatIHit.collider.gameObject.GetComponent<Medicine> ().whatMedAmI == Medicine.MedicineType.movement) {
						GM.instance.hideMoveMed ();
						GM.instance.playerHidden ();
						Destroy (whatIHit.collider.gameObject);
					}
				}
			}

		} else {
			touching = false;
		}
		if (touching = false) {
			GM.instance.hideMoveMed ();
		}


	}
}
