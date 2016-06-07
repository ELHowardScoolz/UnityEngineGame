using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	float moveSpeed = 2.0f;
	float turnSpeed = 50.0f;
	float enRange = 25.0f;

	int health = 10;

	//float gravity = 20.0f;
	//public float shootRange = 20.0f;
	public Transform player;
	Quaternion lookAt;
	Vector3 lastPosistion = Vector3.zero;
	//Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, player.position) <= enRange) 
		{

		if (lastPosistion != player.transform.position) {
			lastPosistion = player.transform.position;
			lookAt = Quaternion.LookRotation (lastPosistion - transform.position);
		}

		if (transform.rotation != lookAt) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, turnSpeed * Time.deltaTime); 
		}
			
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Sword")) 
		{
			health -= 5;
		}

		if (other.gameObject.CompareTag ("Bullet")) 
		{
			Destroy (gameObject);
		}
	}
}
