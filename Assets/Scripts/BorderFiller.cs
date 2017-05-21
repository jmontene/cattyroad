using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderFiller : MonoBehaviour {

	public GameObject[] fillingObjects;
	public int fillAmount;
	private int _units;

	void Start ()
	{
		_units = (int)transform.localScale.x;
		GameObject fillObj;
		int randomIdx;
		for (int i = 0; i < fillAmount; i++)
		{
			randomIdx = Random.Range (0, fillingObjects.Length);
			fillObj = Instantiate (fillingObjects [randomIdx]);
			fillObj.transform.position = new Vector3 (i, fillObj.transform.position.y, transform.position.z);
			fillObj.transform.SetParent (transform);
			randomIdx = Random.Range (0, fillingObjects.Length);
			fillObj = Instantiate (fillingObjects [randomIdx]);
			fillObj.transform.position = new Vector3 (_units - 1 - i, fillObj.transform.position.y, transform.position.z);
			fillObj.transform.SetParent (transform);
		}
	}
}
