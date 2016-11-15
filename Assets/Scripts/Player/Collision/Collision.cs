using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Collision {
	private Vector2 _rawPixelWidth;
	private Vector2 _pixelWidth;
	private GameObject _object;
	private Bounds _bound;

	public Collision(GameObject go, MeshFilter meshFilter) {
		_object = go;
		if (go == null || meshFilter == null) {
//			Debug.LogErrorFormat ("Null reference ? : ", go);
//			Debug.LogErrorFormat ("Null reference ? : ", spriteRenderer);	
//			return;
		}
		Mesh mesh = meshFilter.mesh;
		_bound = mesh.bounds;

	}

	public Vector2 GetPixels () {
//		_rawPixelWidth = new Vector2(_meshFilter.sprite.rect.size.x, _meshFilter.sprite.rect.size.y);
		_pixelWidth = new Vector2(_bound.size.x, _bound.size.y);
		return _pixelWidth;
	}

	public bool ScreenCollision() {
		float height = 2 * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;

		if (_object.transform.position.x - _pixelWidth.x / 2 < Camera.main.transform.position.x - width / 2 ||
		    _object.transform.position.x + _pixelWidth.x / 2 > Camera.main.transform.position.x + width / 2) {
			return true;
		} else {
			return false;
		}
	}
		
	public GameObject GetHitObject(string _mask) {
		GetPixels ();
		RaycastHit2D hit2d = Physics2D.Raycast (new Vector2(_object.transform.position.x, _object.transform.position.y + _pixelWidth.y), new Vector2(0, -_pixelWidth.y), _pixelWidth.y, LayerMask.GetMask(_mask));
		Debug.DrawRay (new Vector2 (_object.transform.position.x, _object.transform.position.y + _pixelWidth.y), new Vector2(0, -_pixelWidth.y), Color.black);
		if (hit2d) {
			ExecuteEvents.Execute<ICollision> (_object, null, (x, y) => x.CollisionEnter (hit2d.transform.gameObject));
		}
//
//		return hit2d.transform.gameObject;

		return null;
	}

	public bool HasCollision (string _mask) {
		GetPixels ();
		Debug.DrawRay (new Vector2 (_object.transform.position.x - _pixelWidth.x / 2, _object.transform.position.y), new Vector2(_pixelWidth.x, 0), Color.red);
		if (Physics2D.Raycast (new Vector2 (_object.transform.position.x - _pixelWidth.x / 2, _object.transform.position.y), Vector2.right, _pixelWidth.x, LayerMask.GetMask (_mask))) {
			return true;
		} else {
			return false;
		}
	}
}
