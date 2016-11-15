using UnityEngine;
using System.Collections;

public static class TransformExtensions  {
	public static bool HasRigidbody(this Transform t) {
		if (t.GetComponent<Rigidbody>() != null || t.GetComponent<Rigidbody2D>() != null) {
			return true;	
		}
		return false;
	}
}
