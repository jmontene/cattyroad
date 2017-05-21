using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFiller : MonoBehaviour {

	public GameObject[] paths;
	public int pathsAmount;
	public float continuousPaths;
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
		int randomIdx;
		GameObject obs;

		Transform previousRow = RowController.Instance.PreviousRow;
		if (previousRow != null && previousRow.GetComponent<PathFiller> ())
		{
			Transform[] previousPaths = previousRow.GetInmediateChildren ().ToArray ();
			for (int i = 0; i < continuousPaths && i < previousPaths.Length; i++)
			{
				randomIdx = Random.Range (0, previousPaths.Length);
				Transform previousPath = previousPaths [randomIdx];
				obs = Instantiate (paths [randomIdx]);
				float xPos = previousPath.position.x;
				obs.transform.position = new Vector3 (xPos, obs.transform.position.y, transform.position.z);
				obs.transform.SetParent (transform);
				indexesAvailable.Remove ((int)xPos);
				pathsAmount--;
			}
		}

		for (int i = 0; i < pathsAmount && i < _units - fillAmount * 2; i++)
		{
			randomIdx = Random.Range (0, paths.Length);
			obs = Instantiate (paths [randomIdx]);
			obs.transform.position = new Vector3 (indexesAvailable[i], obs.transform.position.y, transform.position.z);
			obs.transform.SetParent (transform);
		}
	}
}
