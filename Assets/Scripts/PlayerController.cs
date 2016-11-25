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

	}

	void FixedUpdate() {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		rb.transform.position += move * speed * Time.deltaTime;

	}
}
