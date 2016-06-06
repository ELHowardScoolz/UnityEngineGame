using UnityEngine;
using System.Collections;

public class TrackingAim : MonoBehaviour {

	public float speed = 3.0f;
	public GameObject target = null;

	Vector3 lastPosistion = Vector3.zero;
	Vector3 direction = Vector3.zero;
	Quaternion lookAt;

	bool fired = false;
	//GameObject launcher;
	int damage = 5;
	int health = 5;

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
				transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, speed * Time.deltaTime); 
			}

			if (fired) {
				transform.position += direction * (speed * Time.deltaTime);
			}
		}
	}

	public void TargetSet(GameObject targetS){
		target = targetS;
	}
}
