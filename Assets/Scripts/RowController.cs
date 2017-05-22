using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

	private static RowController _instance;

	public static RowController Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	public GameObject[] rowTypes;
	public int rowAmount;
	public GameObject freeRow;
	public int startFreeRows;
	public int lengthFreeRows;
	private float _lastZ;
	private GameObject _row;
	private int _randomIdx;

	void Start ()
	{
		for (int i = 0; i < rowAmount; i++)
		{
			if (freeRow != null && i == startFreeRows) 
			{
				for (int j = 0; j < lengthFreeRows; j++)
				{
					_row = Instantiate (freeRow);
					Vector3 pos = _row.transform.position;
					pos.z = _lastZ;
					_row.transform.position = pos;
					_row.transform.SetParent (transform);
					_lastZ++;
				}
				i += lengthFreeRows - 1;
			}
			else
			{
				AddRow ();
			}
		}
	}

	public void DestroyRow()
	{
		Destroy(transform.GetChild (0).gameObject);
	}

	public void AddRow()
	{
		_randomIdx = Random.Range (0, rowTypes.Length);
		_row = Instantiate (rowTypes[_randomIdx]);
		Vector3 pos = _row.transform.position;
		pos.z = _lastZ;
		_row.transform.position = pos;
		_row.transform.SetParent (transform);
		Assigner asgn = _row.GetComponent<Assigner> ();
		if (asgn != null)
			asgn.Assign ();
		_lastZ++;
	}


	public Transform GetPreviousRow(int depth)
	{
		if (transform.childCount > 1 + depth)
			return transform.GetChild (transform.childCount - 2 - depth);
		return null;
	}
}
