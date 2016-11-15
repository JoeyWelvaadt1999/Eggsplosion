using UnityEngine;
using System.Collections;

public class Rounds : MonoBehaviour {
	private int _round;
	public int Round {get{ return _round;}}

	private void Start() {
		IncreaseRound ();
	}

	public void IncreaseRound() {
		_round += 1;
	}
}
