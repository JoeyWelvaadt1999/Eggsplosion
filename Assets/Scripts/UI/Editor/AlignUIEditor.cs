using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(AlignUI))]
[CanEditMultipleObjects]
public class AlignUIEditor : Editor {
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		AlignUI align = (AlignUI)target;
		align.CalculatePosition ();
	}
}
