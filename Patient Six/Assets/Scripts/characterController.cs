using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe += Time.deltaTime;

		if (Input.GetAxis ("Vertical") > 0) {
			transform.Translate (straffe / 100, 0, translation);
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (straffe / 100, 0, translation);
		}
		if (Input.GetAxis ("Vertical") < 0) {
			transform.Translate (straffe / 100, 0, translation);
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (straffe / 100, 0, translation);
		}
//		transform.Translate (straffe, 0, translation);

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

	}
}
