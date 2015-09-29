using UnityEngine;
using System.Collections;

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

	//Test for terrain in front of the player with a raycast 
	public static RaycastHit[] startRayCastAllHits(float distance){
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;

		return Physics.RaycastAll(position, direction, distance);;
	}
}
