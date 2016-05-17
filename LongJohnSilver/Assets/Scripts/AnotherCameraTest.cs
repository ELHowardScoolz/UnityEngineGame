using UnityEngine;
using System.Collections;

public class AnotherCameraTest : MonoBehaviour {

	public GameObject target;
	public float damp = 1;
	Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = transform.position - target.transform.position;
	}

	void LateUpdate(){
		Vector3 desiredPosistion = target.transform.position + offSet;
		Vector3 posistion = Vector3.Lerp (transform.position, desiredPosistion, Time.deltaTime * damp);
		transform.position = posistion;

		transform.LookAt (target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
