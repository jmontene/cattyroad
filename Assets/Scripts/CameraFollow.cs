using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float followSpeed = 1f;
	public Transform target;

	public float distanceThreshold = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float curDistance = Vector3.Distance(target.position, new Vector3(target.position.x, target.position.y, transform.position.z));
		if(curDistance >= distanceThreshold){
			transform.Translate(transform.forward * followSpeed * Time.deltaTime);
		}
	}
}
