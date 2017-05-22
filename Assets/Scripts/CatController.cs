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

	public LayerMask blockLayer;
	public LayerMask deathLayer;
	public LayerMask platformLayer;

	private bool dead = false;
	private bool falling = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(dead){
			if(falling){
				Fall();
			}
			return;
		}
		ProcessMovement();
		CheckBelow();
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

		if (Physics.Linecast (transform.position, targetPos, blockLayer))
			moving = false;
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

	void CheckBelow(){
		if(Physics.Linecast(transform.position, transform.position + (Vector3.down * tileSize), platformLayer)){
			return;
		}
		if(Physics.Linecast(transform.position, transform.position + (Vector3.down * tileSize), deathLayer)){
			Fall();
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "KillCat"){
			Die();
		}
	}

	void Fall(){
		dead = true;
		falling = true;
		transform.Translate(transform.up*-1*speed*Time.deltaTime);
	}

	void Die(){
		dead = true;
		Destroy(gameObject);
	}

	public bool IsDead(){
		return dead;
	}
}
