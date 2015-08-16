using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelDesigner))]
public class LevelDesignerEditor : Editor {

	private LevelDesigner script;
	private Vector3 pos;

	void OnEnable(){
		script = (LevelDesigner)target;
	}

	void OnSceneGUI(){
		RaycastHit hit = RayCastManager.startRayCastFromGUI(3000);
		script.pos = hit.point;
		SceneView.RepaintAll();

		if(GUI.changed)
			EditorUtility.SetDirty(target);
	}
}
