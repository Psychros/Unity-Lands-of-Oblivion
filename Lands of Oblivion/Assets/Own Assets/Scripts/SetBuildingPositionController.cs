using UnityEngine;
using System.Collections;

public class SetBuildingPositionController : MonoBehaviour {

	public static SetBuildingPositionController instance;
	public GameObject building = null;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//The building follows the mouse
		if(building != null){
			RaycastHit hit = RayCastManager.startRayCast(15);
			if(hit.collider.transform.gameObject.tag == "Terrain")
				building.transform.position = hit.point;
		}
	}
}
