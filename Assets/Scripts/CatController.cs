using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	public float tileSize = 1.0f;
	//Tiles per second
	public float speed = 1.0f;

	private bool moving = false;
	private int dirRight;
	private int dirForward;
	private float distanceMoved;
	private Vector3 originalPos;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float forward = Input.GetAxis("Vertical");
		if(forward != 0 && !moving){
			targetPos = transform.position + (transform.forward * forward * tileSize);
			moving = true;
		}

		float right = Input.GetAxis("Horizontal");
		if(right != 0 && !moving){
			targetPos = transform.position + (transform.right * right * tileSize);
			moving = true;
		}

		if(moving){
			Move();
			if(transform.position == targetPos){
				moving = false;
			}
		}
	}

	void Move(){
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
	}
}
