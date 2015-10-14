using UnityEngine;
using System.Collections;

public class SetBuildingPositionController : MonoBehaviour {

	public static SetBuildingPositionController instance;
	public GameObject building = null;
	public Building buildingScript = null;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//The building follows the mouse
		if(building != null){
			Vector3 pos = RayCastManager.getTerrainPosition(200, buildingScript.minHeight, buildingScript.maxHeight);
			if(pos != Vector3.zero)
				building.transform.position = pos;
		}
	}
}
