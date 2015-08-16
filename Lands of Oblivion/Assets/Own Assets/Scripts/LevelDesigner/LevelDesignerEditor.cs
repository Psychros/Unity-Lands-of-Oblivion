using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelDesigner))]
public class LevelDesignerEditor : Editor {

	private LevelDesigner script;

	void OnEnable(){
		script = (LevelDesigner)target;
	}

	void OnSceneGUI(){
		RaycastHit hit = RayCastManager.startRayCastFromGUI(3000);

		if(!script.pos.Equals(hit.point)){
			script.pos = hit.point;
			SceneView.RepaintAll();
		}

		//Test for Input
		Event e = Event.current;
		if(e.type == EventType.mouseDown){
			//Left mouse delete objects
			if(e.button == 0){

			}

			//Right mouse create objects
			if(e.button == 0){
				for(int i=0; i<script.numberOfObjects; i++){

				}
			}
		}

		if(GUI.changed)
			EditorUtility.SetDirty(target);
	}
}
