using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {
	[SerializeField]private Transform _topPoint;
	[SerializeField]private Transform _bottomPoint;
	[SerializeField]private Transform _leftPoint;
	[SerializeField]private Transform _rightPoint;
	private float _distY;
	private float _distX;

	private void Start() {
		_distY = _topPoint.position.y - _bottomPoint.position.y;
		_distX = _rightPoint.position.x - _leftPoint.position.x;
		CameraToFieldSize ();
	}

	private void CameraToFieldSize() {
		float camHeight = _distY / 2;
		float camWidth = (_distX/2) / Camera.main.aspect;
	
		if (camHeight > camWidth) {
			Camera.main.orthographicSize = camHeight;
		} else {
			Camera.main.orthographicSize = camWidth;
		}

		Camera.main.transform.position = new Vector3 ((_rightPoint.position.x + _leftPoint.position.x) / 2, (_topPoint.position.y + _bottomPoint.position.y)/2, Camera.main.transform.position.z);
	}
}
