using UnityEngine;
using System.Collections;

public class PlayerPhysic : MonoBehaviour {
	[SerializeField]private bool _useGravity;
	public bool UseGravity{get{ return _useGravity;} set{_useGravity = value;}}

	[SerializeField]private Vector2 _gravityScale;
	public Vector2 GravityScale{get{ return _gravityScale;} set{_gravityScale = value;}}

	private Collision _coll;

	private void Start() {
		_coll = new Collision (this.gameObject, GetComponent<MeshFilter>());
	}

	private void Update() {
		Gravity ();

		_coll.GetHitObject (Layers._ground);
	}

	private void FixedUpdate () {
		ResetRigidbody ();
	}

	private void Gravity() {
		if (_useGravity) {
			if (!_coll.HasCollision (Layers._ground)) {
				Vector2 position = transform.position;
				position = position - _gravityScale;
				transform.position = position;
			}
		}
	}

	private void ResetRigidbody() {
		bool hasColl = _coll.ScreenCollision ();
	}

}
