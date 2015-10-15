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
	public static RaycastHit[] startRayCastAllHits(float distance){
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;

		return Physics.RaycastAll(position, direction, distance);;
	}

	//returns Vector3.zero if there is no point
	public static Vector3 getTerrainPosition(float distance, float height1, float height2){
		RaycastHit[] hits = RayCastManager.startRayCastAllHits(distance);
		
		foreach(RaycastHit hit in hits){
			if(hit.collider.transform.gameObject.tag == "Terrain" && hit.point.y >= height1 && hit.point.y <= height2){
				return hit.point;
			}
		}

		return Vector3.zero;
	}

	public static Vector3 getTerrainPosition(float distance){
		return getTerrainPosition(distance, 0, 1000000);
	}
}
