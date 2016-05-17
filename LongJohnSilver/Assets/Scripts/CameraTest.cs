using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour {

	public GameObject target;
	//public float damp = 1;
	//Vector3 offset;

	// Use this for initialization
	void Start () {
		//offset = target.transform.position - transform.position;
	}

	void LateUpdate(){
		//float currentAngle = transform.eulerAngles.y;
		//float desiredAngle = target.transform.eulerAngles.y;
		//float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damp);

		//Quaternion roatation = Quaternion.Euler(0, angle, 0);
		//transform.position = target.transform.position - (roatation * offset);
		transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
