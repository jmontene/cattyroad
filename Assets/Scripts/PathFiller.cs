using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFiller : Assigner {

	public GameObject[] paths;
	public int pathsAmount;
	public int continuousPaths = 1;
	private BorderFiller _rowFiller;
	private int _units;
	private int[] _continuousPathIdx;

	void Awake ()
	{
		_continuousPathIdx = new int[continuousPaths];
		_units = (int)transform.localScale.x;
		_rowFiller = GetComponent<BorderFiller> ();
	}

	public override void Assign()
	{
		int fillAmount = 0;
		if (_rowFiller != null)
			fillAmount = _rowFiller.fillAmount;
		List<int> indexesAvailable = new List<int> ();
		for (int i = 0 + fillAmount; i < _units - fillAmount; i++)
			indexesAvailable.Add (i);
		indexesAvailable.Shuffle ();
		int randomIdx;
		GameObject obs;
		Transform previousRow = RowController.Instance.GetPreviousRow(0);
		if (previousRow != null)
		{
			PathFiller pf = previousRow.GetComponent<PathFiller> ();
			if (pf != null)
			{
				Transform previousRow2 = RowController.Instance.GetPreviousRow(0);


				Transform[] previousPaths = previousRow.GetInmediateChildren ().ToArray ();
				List<int> continuousAvailable = new List<int> ();
				for (int i = 0; i < pf._continuousPathIdx.Length; i++)
					continuousAvailable.Add (i);
				continuousAvailable.Shuffle ();
				for (int i = 0; i < _continuousPathIdx.Length && i < pf._continuousPathIdx.Length; i++)
				{
					Transform previousPath = previousPaths [continuousAvailable[i]];
					randomIdx = Random.Range (0, paths.Length);
					obs = Instantiate (paths [randomIdx]);
					float xPos = previousPath.position.x;
					obs.transform.position = new Vector3 (xPos, obs.transform.position.y, transform.position.z);
					obs.transform.SetParent (transform);
					indexesAvailable.Remove ((int)xPos);
					pathsAmount--;
					_continuousPathIdx [_continuousPathIdx.Length - continuousPaths] = continuousAvailable [i];
					continuousPaths--;
					continuousAvailable.Remove (continuousAvailable [i]);
				}
			}
		}
		for (int i = 0; i < pathsAmount && i < _units - fillAmount * 2; i++)
		{
			randomIdx = Random.Range (0, paths.Length);
			obs = Instantiate (paths [randomIdx]);
			obs.transform.position = new Vector3 (indexesAvailable[i], obs.transform.position.y, transform.position.z);
			obs.transform.SetParent (transform);
			if (continuousPaths > 0)
			{
				_continuousPathIdx [_continuousPathIdx.Length - continuousPaths] = indexesAvailable [i];
				continuousPaths--;
			}
		}

	}
}
