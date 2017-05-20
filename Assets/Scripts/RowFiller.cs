using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowFiller : MonoBehaviour {

	public GameObject[] fillingObjects;
	public int fillAmount;
	private int _units;

	void Start ()
	{
		_units = (int)transform.localScale.x;
		GameObject fillObj;
		Vector3 pos;
		int randomIdx;
		for (int i = 0; i < fillAmount; i++)
		{
			randomIdx = Random.Range (0, fillingObjects.Length - 1);
			fillObj = Instantiate (fillingObjects [randomIdx]);
			pos = fillObj.transform.position;
			pos.x = i;
			fillObj.transform.localPosition = pos;
			fillObj.transform.SetParent (transform);
			randomIdx = Random.Range (0, fillingObjects.Length - 1);
			fillObj = Instantiate (fillingObjects [randomIdx]);
			pos = fillObj.transform.position;
			pos.x = _units - 1 - i;
			fillObj.transform.localPosition = pos;
			fillObj.transform.SetParent (transform);
		}
	}
}
