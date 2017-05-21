using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExt {

	public static List<Transform> GetInmediateChildren(this Transform parent)
	{
		List<Transform> children = new List<Transform> ();
		foreach (Transform t in parent)
			children.Add (t);
		return children;
	}
}
