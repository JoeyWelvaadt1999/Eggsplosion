using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AlignUI : MonoBehaviour {
	[SerializeField]private Canvas _canvas;
	[Range(-100f,100f)][SerializeField]private float _percentageX;
	[Range(-100f,100f)][SerializeField]private float _percentageY;
	[Range(1f,2f)][SerializeField]private float _scale;
	[SerializeField]private float _width;
	[SerializeField]private float _height;
	private RectTransform _canvasRect;
	private RectTransform _rectTransform;

	private Rect _rect;

	public float Scale {
		get { 
			return _scale;
		}
	}

	void Start() {
		_canvasRect = _canvas.GetComponent<RectTransform> ();
		_rectTransform = GetComponent<RectTransform> ();
	}

	public Vector2 CalculatePosition() {
		_canvasRect = _canvas.GetComponent<RectTransform> ();
		_rectTransform = GetComponent<RectTransform> ();
		SetWidthHeight ();
		float x = 0 + ((_canvasRect.rect.width / 2) / _percentageX - (_rectTransform.rect.width / 2) / _percentageX);
		float y = 0 + ((_canvasRect.rect.height / 2) / _percentageY - (_rectTransform.rect.height / 2) / _percentageY);
		_rectTransform.anchoredPosition = new Vector2(x, y);
		return new Vector2 (x, y);
	}
		

	private void SetWidthHeight() {
		if (_width * _scale <= _canvasRect.rect.width) {
			_rect.width = _width * _scale;
			_rect.height = _height * _scale;

		}

		_rectTransform.sizeDelta = new Vector2(_rect.width, _rect.height);
//		_rectTransform.localScale = new Vector2 (1, 1);
	}
		
	void Update () {
		SetWidthHeight ();
		_rectTransform.anchoredPosition = CalculatePosition ();
	}

	void OnValidate() {
		if (_percentageX == 0) {
			_percentageX = 1;

		}

		if (_percentageY == 0) {
			_percentageY = 1;
		}
	}
}
