using UnityEngine;
using System.Collections;

public class RayCastManager : MonoBehaviour {

	public static RaycastHit startRayCast(float distance){
		//Test for something in front of the player with a raycast 
		RaycastHit hit;
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;
		Physics.Raycast(position, direction, out hit, distance);

		return hit;
	}
}
