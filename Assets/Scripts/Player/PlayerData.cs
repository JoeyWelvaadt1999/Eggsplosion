using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerData : MonoBehaviour {
	private Rigidbody2D _rb2d;
	public Rigidbody2D Rb2d {get{return _rb2d;}}

	private Collision _coll;
	public Collision Coll { get{return _coll;}}


	private void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
		_coll = new Collision (this.gameObject, GetComponent<MeshFilter> ());
	}
}
