using UnityEngine;
using System.Collections;
using UnityEditor;

public class RayCastManager : MonoBehaviour {

	//Test for something in front of the player with a raycast 
	public static RaycastHit startRayCast(float distance){
		RaycastHit hit;
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;
		Physics.Raycast(position, direction, out hit, distance);

		return hit;
	}

	//Test for terrain in front of the player with a raycast 
	public static RaycastHit startRayCastTerrain(float distance){
		RaycastHit hit;
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;
		Physics.Raycast(position, direction, out hit, distance, 8);

		return hit;
	}

	//Test for something in front of the GU with a raycast 
	public static RaycastHit startRayCastFromGUI(float distance){
		RaycastHit hit;
		Vector3 direction = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).direction;
		Vector3 position  = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
		Physics.Raycast(position, direction, out hit, distance);
		
		return hit;
	}
}
