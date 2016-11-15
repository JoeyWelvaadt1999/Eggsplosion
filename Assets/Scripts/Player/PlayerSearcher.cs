using UnityEngine;
using System.Collections;

public class PlayerSearcher : MonoBehaviour {
	private GameObject _bomb;
	private float _radius = 5f;
	private float _startRadius = 5f;
	private Main _main;


	private void Start() {
		_main = FindObjectOfType<Main> ();
		_bomb = GameObject.Find ("Bomb");
		_bomb.transform.parent = transform;
		_radius = 5f;

	}

	private void Update() {
		_bomb.transform.position = transform.position;
		_radius = _startRadius - ((_startRadius / _main.GameTime) * (_main.GameTime-_main.PlayTime ));
		_bomb.gameObject.transform.localScale = new Vector2 (((_radius / (3.38f /2))), (_radius / ( 3.38f / 2)));
		CheckRadius ();
		SearchRadius ();
	}

	private void CheckRadius() {
		if (_radius < 0) {
			Destroy (this.gameObject);
			_main.ResetTimer ();
			PlayerRunner[] runners = FindObjectsOfType<PlayerRunner> (); 
			int temp = Random.Range (0, runners.Length);
			if (runners.Length > 1) {
				Debug.Log ("Reset");
				SetSearcher (runners [temp].gameObject);
			}
		}
	}

	private void SearchRadius() {
		Collider2D coll = Physics2D.OverlapCircle (transform.position, _radius, LayerMask.GetMask(Layers._runner));
	

		if (coll != null) {
			SetSearcher (coll.gameObject);
		}
	}

//	void OnDrawGizmos() {
//		if (_main != null) {
//			Gizmos.color = new Color (0 + ((1 / _main.GameTime) * (_main.GameTime - _main.PlayTime)), 1 - ((1 / _main.GameTime) * (_main.GameTime - _main.PlayTime)), 0);
//		}
//		Gizmos.DrawWireSphere (transform.position, _radius);
//	}

	private void SetSearcher(GameObject coll) {
		PlayerRunner runner = coll.GetComponent<PlayerRunner> ();
		if (!runner.IsTimeout) {
			coll.gameObject.layer = LayerMask.NameToLayer (Layers._searcher);
			this.gameObject.layer = LayerMask.NameToLayer (Layers._runner);

			Destroy (coll.gameObject.GetComponent<PlayerRunner> ());
			coll.gameObject.AddComponent<PlayerSearcher>();
			Destroy (this.gameObject.GetComponent<PlayerSearcher> ());
			this.gameObject.AddComponent <PlayerRunner>();
			this.GetComponent<PlayerRunner> ().InitTimeout();

			ControllerInput[] inputs = FindObjectsOfType<ControllerInput> ();
			for (int i = 0; i < inputs.Length; i++) {
				inputs [i].FindComponents ();
			}
		}
	}
}
