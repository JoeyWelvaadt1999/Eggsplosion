using UnityEngine;
using System.Collections;

public class SetSize : MonoBehaviour {
	[SerializeField]private Vector2 _pixelSize;

	void Update () {
		float height = 2 * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		transform.localScale = new Vector2 (width / (_pixelSize.x / 100), height / (_pixelSize.y / 100));
	}
}
