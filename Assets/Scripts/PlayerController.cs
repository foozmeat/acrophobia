using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	private Vector3 initialPosition;
	private Quaternion initialRotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		initialPosition = rb.transform.position;
		initialRotation = rb.transform.rotation;
		rb.centerOfMass = new Vector3 (0, -1, 0);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.transform.position = initialPosition;
			rb.transform.rotation = initialRotation;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero; 
		}

		float fYRot = Camera.main.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, fYRot, transform.eulerAngles.z );

	}

	void FixedUpdate() {
		
		if (Input.GetAxis ("Vertical") != 0) {
			rb.AddForce(transform.forward * speed * Input.GetAxis ("Vertical"));
		}

		if (Input.GetAxis ("Horizontal") != 0) {
			rb.AddForce(transform.right * speed * Input.GetAxis ("Horizontal"));
		}


	}
}
