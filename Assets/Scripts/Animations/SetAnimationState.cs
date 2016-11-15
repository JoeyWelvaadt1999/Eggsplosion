using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;
public enum AnimationStates
{
	Run,
	Idle,
	Jump,
	Fall
}

public class SetAnimationState : MonoBehaviour {
	[SerializeField]private string _color;
	private string _animName;
	private bool _hasEggAnim;
	private SkeletonAnimation _skeletonAnimation;
	private SkeletonUtility _skeletonUtility;


	private void Start() {
		_skeletonAnimation = GetComponent<SkeletonAnimation> ();
		_skeletonUtility = GetComponent<SkeletonUtility> ();

	}

	public void SetState(AnimationStates state) {
		PlayerSearcher _search = GetComponent<PlayerSearcher> ();
		switch (state) {
		case AnimationStates.Fall:
			_animName = "Fall";
			if (_search != null) {
				_animName = "EggFall";
			}
			break;
		case AnimationStates.Idle:
			_animName = "Idle";
			if (_search != null) {
				_animName = "Egg Idle";
			}
			break;
		case AnimationStates.Jump:
			_animName = "Jump";
			if (_search != null) {
				_animName = "Egg Jump";
			}
			break;
		case AnimationStates.Run:
			_animName = "Run";
			if (_search != null) {
				
				_animName = "EggRun";
			}
			break;
		}

//		if (_skeletonAnimation.AnimationName != _animName) {
		if (_search != null && !_hasEggAnim) {
			_skeletonAnimation.initialSkinName = "Egg" + _color;
			ResetCharacter ();
			_hasEggAnim = true;
		} else if(_search == null && _hasEggAnim) {
			_skeletonAnimation.initialSkinName = _color+"Character";
			_hasEggAnim = false;
			ResetCharacter ();
		}
		_skeletonAnimation.AnimationName = _animName;
//		}
	}

	public void FlipX(bool value) {
		_skeletonUtility.skeletonAnimation.Skeleton.flipX = value;
	}

	private void ResetCharacter() {
		SkeletonRenderer component = GetComponent<SkeletonRenderer> ();
		if (component.skeletonDataAsset != null) {
			foreach (AtlasAsset aa in component.skeletonDataAsset.atlasAssets) {
				if (aa != null)
					aa.Reset();
			}
			component.skeletonDataAsset.Reset();
		}
		component.Initialize(true);
	}
}
