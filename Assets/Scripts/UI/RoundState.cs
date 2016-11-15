using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundState : MonoBehaviour {
	[SerializeField]private Sprite _state1;
	[SerializeField]private Sprite _state2;
	[SerializeField]private Sprite _state3;
	[SerializeField]private Image _egg;
	private Rounds _round;

	private void Start() {
		_round = GetComponent<Rounds> ();
	}

	private void Update() {
		switch (_round.Round) {
		case 1:
			if (_egg.sprite != _state1) {
				_egg.sprite = _state1;
			}
			break;
		case 2:
			if (_egg.sprite != _state2) {
				_egg.sprite = _state2;
			}
			break;
		case 3:
			if (_egg.sprite != _state3) {
				_egg.sprite = _state3;
			}
			break;
		}
	}
}
