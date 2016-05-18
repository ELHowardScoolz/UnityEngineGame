using UnityEngine;
using System.Collections;

public class ReferenceTest : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 8.0f;
	public float turnSpeed = 60;
	public float gravity = 20.0f;
	private Vector3 moveDir = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded) {
			moveDir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= moveSpeed;

			//float ver = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			//transform.Translate (0, 0, ver);

			if (Input.GetButton ("Jump")) {
				moveDir.y = jumpSpeed;
			}
		}

		float hor = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate (0, hor, 0);

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}
}
