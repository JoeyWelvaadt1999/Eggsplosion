using UnityEngine;
using System.Collections;

public class RoundAudio : MonoBehaviour {
	[SerializeField]private AudioClip _round1;
	[SerializeField]private AudioClip _round2;
	[SerializeField]private AudioClip _round3;
	private Rounds _rounds;
	private AudioSource _source;

	private void Start() {
		_rounds = GetComponent<Rounds> ();
		_source = GetComponent<AudioSource> ();
	}

	private void Update() {
		SetSound ();
	}

	private void SetSound() {
		switch (_rounds.Round) {
		case 1:
			QueueSound (_round1);
			break;
		case 2:
			QueueSound (_round2);
			break;
		case 3:
			QueueSound (_round3);
			break;
		}
	}

	private void QueueSound(AudioClip sound) {
		if (!_source.isPlaying) {
			_source.PlayOneShot (sound);
		}
	}
}
