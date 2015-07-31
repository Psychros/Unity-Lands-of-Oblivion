using UnityEngine;
using System;
using System.Collections;

public class BuildBuildingEvent : UserEvent {

	public void execute(){
		//Get the position where the player is looking at the terrain
		RaycastHit hit = RayCastManager.startRayCast(15);


		//Buildings can only be build on terrains
		try{
			if(hit.transform.gameObject.tag == "Terrain"){
				Vector3 pos = hit.point;

				GameObject building = Instantiate(BuildingManager.instance.storeHouse);
				building.transform.parent = BuildingManager.instance.buildings.transform;
				building.transform.position = pos;
			}
		} 
		catch(Exception e){
			Debug.LogError(e);
		}
	}
}