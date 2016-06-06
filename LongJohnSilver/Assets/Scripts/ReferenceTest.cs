﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReferenceTest : MonoBehaviour {

	public float moveSpeed = 10;
	//public float jumpSpeed = 8.0f;
	public float turnSpeed = 60;
	public float gravity = 20.0f;
	private Vector3 moveDir = Vector3.zero;

	private int gold;
	private int silver;
	public Text goldCount;
	public Text silverCount;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        gold = 0;
		silver = 0;
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

            //if (Input.GetButton ("Jump")) {
            //	moveDir.y = jumpSpeed;
            //}
        }

        if (Input.GetKey("up") || Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
        {
            anim.SetTrigger("Move");
        }
        else
        {
            anim.SetTrigger("stop");
        }

        if(Input.GetKey("mouse 1"))
        {
            anim.SetTrigger("Change");
        }

        if (Input.GetKey("mouse 0"))
        {
            anim.SetTrigger("attack");
        }

        float hor = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate (0, hor, 0);

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Doubloon")) {
			other.gameObject.SetActive (false);
			gold += 1;
			UpdateGold ();
		}

		if (other.gameObject.CompareTag ("Piece")) {
			other.gameObject.SetActive (false);
			silver += 1;
			UpdateSilver ();
		}
	}

	void UpdateGold(){
		goldCount.text = "" + gold;
	}

	void UpdateSilver(){
		silverCount.text = "" + silver;
	}
}
