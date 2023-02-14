using UnityEngine;
using System.Collections;

#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(LevelDesigner))]
public class LevelDesignerEditor : Editor {

	private LevelDesigner script;

	void OnEnable(){
		script = (LevelDesigner)target;
	}

	void OnSceneGUI(){
		if(script.isActivated){

			RaycastHit hit = startRayCastFromGUI(3000);

			if(!script.pos.Equals(hit.point)){
				script.pos = hit.point;
				SceneView.RepaintAll();
			}

			//Test for Input
			Event e = Event.current;
			if(e.type == EventType.MouseDown){

				//Left mouse delete objects
				if(e.button == 0){

				}

				//Right mouse create objects
				if(e.button == 0){
					for(int i=0; i<script.numberOfObjects; i++){
						createObject();
					}
				}
			}

			if(GUI.changed)
				EditorUtility.SetDirty(target);
		}
	}

	public void createObject(){
		GameObject g;
		g = (GameObject)Instantiate(script.gameObject, script.pos, new Quaternion());
			
		if(script.parent != null){
			g.transform.parent = script.parent;
		}

		Vector3 pos = createRandomVector3();
		float distance = Random.Range(0, script.range);
		pos = pos * distance;

		g.transform.position = g.transform.position + pos;
		//Set the height
		float y = script.terrain.SampleHeight(g.transform.position);
		g.transform.position = new Vector3(g.transform.position.x, y, g.transform.position.z);

		//Rotate the objct
		if(script.rotateRandom){
			Quaternion rotation = new Quaternion();
			rotation.SetLookRotation(createRandomVector3());
			g.transform.rotation = rotation;
		}
	}


	public Vector3 createRandomVector3(){
		//Set a random position in the sphere
		float x = Random.Range(-100f, 100f);
		float z = Random.Range(-100f, 100f);

		Vector3 pos = new Vector3(x, 0, z);
		pos.Normalize();

		if(Random.Range(0, 2) == 0){
			pos = pos * -1;
		}

		return pos;
	}

	//Test for something in front of the GUI with a raycast 
	public static RaycastHit startRayCastFromGUI(float distance){
		RaycastHit hit;
		Vector3 direction = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).direction;
		Vector3 position  = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
		Physics.Raycast(position, direction, out hit, distance);
		
		return hit;
	}
}
#endif