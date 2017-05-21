using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	public float tileSize = 1.0f;
	//Tiles per second
	public float speed = 1.0f;

	private bool moving = false;
	private bool movingForward;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		ProcessMovement();
	}

	void ProcessMovement(){
		float forward = Input.GetAxis("Vertical");
		if(forward != 0 && !moving){
			if(forward > 0){
				RowController.Instance.AddRow();
				movingForward = true;
			}else{
				movingForward = false;
			}
			targetPos = transform.position + (transform.forward * forward * tileSize);
			moving = true;
		}

		float right = Input.GetAxis("Horizontal");
		if(right != 0 && !moving){
			movingForward = false;
			targetPos = transform.position + (transform.right * right * tileSize);
			moving = true;
		}

		if(moving){
			Move();
			if(transform.position == targetPos){
				moving = false;
				if(movingForward) RowController.Instance.DestroyRow();
			}
		}
	}

	void Move(){
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
	}
}
