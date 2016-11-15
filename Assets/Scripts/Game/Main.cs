using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {
	private float _gameTime = 120f; //in seconds
	private Rounds _rounds;
	private float _curTime;
	private float _playTime;
	public float PlayTime {
		get { 
			return _playTime;
		}
	}

	public float GameTime {
		get {
			return _gameTime;
		}
	}

	private void Start() {
		DontDestroyOnLoad (this);
		_rounds = GetComponent<Rounds> ();
	}

	private void Update() {
		_curTime = _curTime + Time.deltaTime;
		_playTime = (int)(_gameTime - _curTime) % _gameTime;
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer(Layers._searcher), LayerMask.NameToLayer(Layers._runner));
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer(Layers._runner), LayerMask.NameToLayer(Layers._runner));
	}

	public void ResetTimer() {
		_gameTime = _gameTime - 20f * _rounds.Round;
		_rounds.IncreaseRound ();
		_curTime = 0;
	}

	public void StartGame() {
		SceneManager.LoadScene (1);
	}
}
