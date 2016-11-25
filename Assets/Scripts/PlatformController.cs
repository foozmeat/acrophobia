using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public float speed = 1.0f;

	private Rigidbody rb;
	private Vector3 initialPosition;
	private Vector3 destination;
	private int move_limit = 1;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		initialPosition = transform.position;
		destination = initialPosition;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Q)) { // Up
			
			destination += new Vector3(0f,speed,0f);
//			rb.AddForce(transform.up * speed);

		} else if (Input.GetKey(KeyCode.E)) { // Down

			if (destination.y > initialPosition.y) {
				destination += new Vector3(0f,-speed,0f);
			}

		}

		if (Mathf.Abs (destination.y - transform.position.y) > move_limit) {
			if (destination.y - transform.position.y > 0) {
				destination.y = transform.position.y + move_limit;
			} else {
				destination.y = transform.position.y - move_limit;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.position = initialPosition;
			destination = initialPosition;
		}

//		rb.MovePosition(transform.position + destination * Time.deltaTime);

		rb.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);

	}

}
