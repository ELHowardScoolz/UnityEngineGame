using UnityEngine;
using System.Collections;

public class TrackingAim : MonoBehaviour {
	public GameObject target = null;

	Vector3 lastPosistion = Vector3.zero;
	Vector3 direction = Vector3.zero;
	Quaternion lookAt;

	public Transform Launcher;
	public Transform player;
	public Rigidbody canonShot;
	float CSpeed = 20.0f;

	//bool fired = false;
	//bool readtofire = false;

	float CRange = 25.0f;
	float timeFire;
	public float timeBetweenShots = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			if (lastPosistion != target.transform.position) {
				lastPosistion = target.transform.position;
				lookAt = Quaternion.LookRotation (lastPosistion - transform.position);
			}

			if (transform.rotation != lookAt) {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, CSpeed * Time.deltaTime); 
			}

			//if (fired) {
			//	transform.position += direction * (speed * Time.deltaTime);
			//}

			if (Vector3.Distance (transform.position, player.position) <= CRange) {
				//readtofire = true;
				if (Time.time >= timeFire) {
					Rigidbody instantiatedProjectile = Instantiate (canonShot, Launcher.position, Launcher.rotation) as Rigidbody;
					instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, CSpeed));
					timeFire = Time.time + timeBetweenShots;
				}
			}
				
		}
	}

	public void TargetSet(GameObject targetS){
		target = targetS;
	}

	//public void FireProc()
	//{
	//	if (readtofire) {
	//		fired = true;
	//		yield return new WaitForSeconds(5);
	//		readtofire = false;
	//	}
	//}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag ("Bullet")) 
		{
			Destroy (gameObject);
		}
	}
}
