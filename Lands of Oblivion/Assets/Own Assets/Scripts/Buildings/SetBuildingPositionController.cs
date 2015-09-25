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
			RaycastHit[] hits = RayCastManager.startRayCastAllHits(200);

			foreach(RaycastHit hit in hits){
				if(hit.collider.transform.gameObject.tag == "Terrain"){
					building.transform.position = hit.point;
					break;
				}
			}
		}
	}
}
