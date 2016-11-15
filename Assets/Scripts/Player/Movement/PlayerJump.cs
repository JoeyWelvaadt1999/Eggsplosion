using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour, ICollision {
	[SerializeField]private Vector2 _startVelocity;
	[SerializeField]private Vector2 _gravity;
	private Vector2 _velocity;
	private float _deltaTime = 0.25f;
	private PlayerData _data;
	private SetAnimationState _state;
	private bool _isJumping = false;

	private void Start() {
		_data = GetComponent<PlayerData> ();
		_velocity = _startVelocity;
		_state = GetComponent<SetAnimationState> ();
	}

	public void Jump() {
		if (_data.Coll.HasCollision(Layers._ground)) {
			StartCoroutine (CalculateJump ());
		}
	}

	public void CollisionEnter (GameObject coll) {
//		GameObject g = coll;
//		float result = ((g.transform.position.y + 0.5f)) - ((transform.position.y));
		float blockY = coll.transform.position.y;
		float blockTop = blockY + 0.5f;
		float posY = transform.position.y;
		float distance = blockY - posY;
		if (_isJumping == false) {
			
				Vector2 pos = transform.position;
				pos.y = blockTop;
				transform.position = pos;
//
		}
	}

	private IEnumerator CalculateJump() {
		_isJumping = true;
		_velocity = _startVelocity;
		while(_isJumping) {
			if (_velocity.y > 0) {
				_state.SetState (AnimationStates.Jump);
			}
			if (_velocity.y < 0){
				_state.SetState (AnimationStates.Fall);
			}
			Vector2 position = transform.position;

			position += _velocity * _deltaTime;
			_velocity += _gravity * _deltaTime;
			Debug.Log (_velocity);
			transform.position = position;
			if (_data.Coll.HasCollision(Layers._ground) && _velocity.y <= 0) {
				_velocity = _startVelocity;
				_isJumping = false;
				_state.SetState (AnimationStates.Idle);
			}
			yield return null;
		}

	}
}
