using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerRenderer : MonoBehaviour {
	[SerializeField]private Text _frontText;
	[SerializeField]private Text _backText;
	private Main _main;

	private void Start() {
		_main = GetComponent<Main> ();
	}

	private void Update() {
		_frontText.text = (_main.PlayTime).ToString();
		_backText.text = _frontText.text;
	}
}
