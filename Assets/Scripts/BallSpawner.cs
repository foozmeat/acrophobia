using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
	public GameObject prefab;
	public Material[] materials;
	private GameObject balls;
	private int i;
	private bool running;
	private int ball_x;
	private int ball_speed;

	void Start()
	{
		balls = new GameObject();
		balls.name = "Balls";
		i = 1;
		ball_x = -10;
		ball_speed = 400;

		StartCoroutine(LaunchBalls());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadPlus) && !running)
		{
			StartCoroutine(LaunchBalls());
		}
	}

	IEnumerator LaunchBalls()
	{
		running = true;
		while (!Input.GetKeyDown(KeyCode.KeypadMinus) && i < 400)
		{
			if (Random.value >= .05) {
				ball_x *= -1;
				ball_speed *= -1;
			}
			Vector3 pos = new Vector3(ball_x, 6, Random.Range(-8, 8));
			Vector3 force = new Vector3(ball_speed, 0, 0);

			GameObject ball = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
			Rigidbody rb = ball.GetComponent<Rigidbody> ();
			rb.AddForce(force);

			ball.name = "Ball" + i.ToString();
			ball.transform.SetParent(balls.transform);

			Renderer rend = ball.GetComponent<MeshRenderer>();
			rend.material = materials[Random.Range(0, materials.Length)];
			yield return null;
			i++;
		}
		running = false;
	}
}
