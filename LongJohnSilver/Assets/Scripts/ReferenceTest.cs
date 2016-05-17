using UnityEngine;
using System.Collections;

public class ReferenceTest : MonoBehaviour {

	public float moveSpeed = 10;
	public float turnSpeed = 60;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate(0, hor, 0);

		float ver = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		transform.Translate(0, 0, ver);
	}
}
