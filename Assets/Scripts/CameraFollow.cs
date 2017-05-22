using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float followSpeed = 1f;
	public float farSpeed = 2f;
	public float closeSpeed = 0.5f;
	public Transform target;

	public float distanceThreshold = 2f;
	public float farThreshold = 3f;
	public float closeThreshold = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null){
			return;
		}
		float curDistance = Vector3.Distance(target.position, new Vector3(target.position.x, target.position.y, transform.position.z));
		if(curDistance >= farThreshold){
			transform.Translate(transform.forward * farSpeed * Time.deltaTime);
		}else if(curDistance >= distanceThreshold){
			transform.Translate(transform.forward * followSpeed * Time.deltaTime);
		}else if(curDistance >= closeThreshold){
			transform.Translate(transform.forward * closeSpeed * Time.deltaTime);
		}
	}
}
