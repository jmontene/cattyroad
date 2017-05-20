using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFiller : MonoBehaviour {

	public GameObject[] obstacles;
	public int obstaclesAmount;
	private BorderFiller _rowFiller;
	private int _units;

	void Start ()
	{
		_units = (int)transform.localScale.x;
		_rowFiller = GetComponent<BorderFiller> ();
		int fillAmount = 0;
		if (_rowFiller != null)
			fillAmount = _rowFiller.fillAmount;
		List<int> indexesAvailable = new List<int> ();
		for (int i = 0 + fillAmount; i < _units - fillAmount; i++)
			indexesAvailable.Add (i);
		indexesAvailable.Shuffle ();
		GameObject obs;
		int randomIdx;
		for (int i = 0; i < obstaclesAmount && i < _units - fillAmount * 2; i++)
		{
			randomIdx = Random.Range (0, obstacles.Length - 1);
			obs = Instantiate (obstacles [randomIdx]);
			obs.transform.position = new Vector3 (indexesAvailable[i], obs.transform.position.y, transform.position.z);
			obs.transform.SetParent (transform);
		}
	}
}
