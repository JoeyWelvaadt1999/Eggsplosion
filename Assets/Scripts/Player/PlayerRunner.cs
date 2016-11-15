using UnityEngine;
using System.Collections;

public class PlayerRunner : MonoBehaviour {
	private float _timeout = 3.0f;
	private float _curTime;
	private bool _isTimeout;
	public bool IsTimeout {
		get { 
			return _isTimeout;
		}
	}

	private void Start() {
		InitTimeout ();
	}

	public void InitTimeout() {
		_isTimeout = true;
		StartCoroutine (Timeout ());
	}

	IEnumerator Timeout() {
		while (_curTime < _timeout) {
			_curTime += Time.deltaTime;
			yield return new WaitForSeconds (0f);
		}
		_isTimeout = false;
		_curTime = 0;
		yield return null;
	}
}
