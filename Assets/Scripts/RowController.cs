using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

	public GameObject[] rowTypes;
	public int rowAmount;
	public GameObject freeRow;
	public int startFreeRows;
	public int lengthFreeRows;
	private float _lastZ;

	void Start ()
	{
		GameObject row;
		int randomIdx;
		for (int i = 0; i < rowAmount; i++)
		{
			if (freeRow != null && i == startFreeRows) 
			{
				for (int j = 0; j < lengthFreeRows; j++)
				{
					row = Instantiate (freeRow);
					Vector3 pos = row.transform.position;
					pos.z = _lastZ;
					row.transform.position = pos;
					row.transform.SetParent (transform);
					_lastZ++;
				}
				i += lengthFreeRows - 1;
			}
			else
			{
				randomIdx = Random.Range (0, rowTypes.Length);
				row = Instantiate (rowTypes[randomIdx]);
				Vector3 pos = row.transform.position;
				pos.z = _lastZ;
				row.transform.position = pos;
				row.transform.SetParent (transform);
				_lastZ++;
			}
		}
	}
}
