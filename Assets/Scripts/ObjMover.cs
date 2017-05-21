using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMover : MonoBehaviour {

	public float speed;

	void Update()
	{
		transform.Translate (speed * Time.deltaTime, 0f, 0f);
	}
}
