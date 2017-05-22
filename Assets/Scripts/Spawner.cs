using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] objs;
	public float minSpawnTime;
	public float maxSpawnTime;
	private bool _fromLeft;
	private int _units;

	void Start ()
	{
		_units = (int)transform.localScale.x;
		_fromLeft = Random.value > 0.5f;
		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds (Random.Range(minSpawnTime, maxSpawnTime));
			int randomIdx = Random.Range (0, objs.Length);
			GameObject obj = Instantiate (objs [randomIdx]);
			if (!_fromLeft)
			{
				Vector3 scale = obj.transform.localScale;
				scale.x *= -1;
				obj.transform.localScale = scale;
				ObjMover mover = obj.GetComponent<ObjMover> ();
				if (mover != null)
					mover.speed *= -1f;
			}
			float spawnX = _fromLeft ? -obj.transform.localScale.x / 2f : _units + obj.transform.localScale.x / 2f;
			spawnX -= 0.5f;
			obj.transform.position = new Vector3 (spawnX, obj.transform.position.y, transform.position.z);
			obj.transform.SetParent (transform);
		}
	}
}
