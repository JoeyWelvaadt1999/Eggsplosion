using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float _speed;
	private PlayerData _data;
	private bool _isDashing;
	private SetAnimationState _state;

	private void Start() {
		_data = GetComponent<PlayerData> ();
		_state = GetComponent<SetAnimationState> ();
	}

	public void Flip(float x) {
		if (x > 0) {
			_state.FlipX (true);
		} else if (x < 0){
			_state.FlipX (false);
		}
	}

	public void Move(float x) {
		_data.Rb2d.velocity = new Vector2 (_speed * x, _data.Rb2d.velocity.y);

		if (x == 0) {
			_data.Rb2d.velocity = new Vector2 (0, _data.Rb2d.velocity.y);
			_state.SetState (AnimationStates.Idle);
		} else {
			_state.SetState (AnimationStates.Run);
		}
	}

	public void InitDash() {
		if (!_isDashing && transform.gameObject.layer == LayerMask.NameToLayer(Layers._searcher)) {
			StartCoroutine (Dash ());
		}
	}

	private IEnumerator Dash() {
		_isDashing = true;
		_speed *= 2;
		yield return new WaitForSeconds (0.5f);
		_speed /= 2;
		_isDashing = false;
	}
}
