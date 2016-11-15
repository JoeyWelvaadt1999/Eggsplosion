using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Spine;
using Spine.Unity;
public class Customizer : MonoBehaviour {
	[SerializeField]private string[] _customizables;
	private string _currentCustom;
	private SkeletonUtility _skeletonUtility;
	private Vector3 _rgb;
	private float _a;
	private Color _color;

	private void Start() {
		_skeletonUtility = GetComponent<SkeletonUtility> ();
	}

	void OnGUI() {
		for (int i = 0; i < _customizables.Length; i++) {
			if (GUILayout.Button (_customizables [i])) {
				_currentCustom = _customizables [i];
				_color = new Color (1, 1, 1);
			}
		}
		_rgb.x = GUILayout.VerticalSlider (_rgb.x, 0f, 1f);	
		_rgb.y = GUILayout.VerticalSlider (_rgb.y, 0f, 1f);	
		_rgb.z = GUILayout.VerticalSlider (_rgb.z, 0f, 1f);

		if (_currentCustom != null) {
			Customize ();
		}

	}

	void Customize() {
		_color = new Color (_rgb.x, _rgb.y, _rgb.z);
		_skeletonUtility.skeletonAnimation.Skeleton.FindSlot (_currentCustom).SetColor (_color);
	}
}
