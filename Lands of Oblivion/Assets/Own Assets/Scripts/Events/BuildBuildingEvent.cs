using UnityEngine;
using System;
using System.Collections;

public class BuildBuildingEvent : UserEvent {

	public void execute(){
		if(SetBuildingPositionController.instance.building == null){
			//Get the position where the player is looking at the terrain
			RaycastHit hit = RayCastManager.startRayCast(15);
			
			
			//Buildings can only be build on terrains
			try{
				if(hit.transform.gameObject.tag == "Terrain"){
					Vector3 pos = hit.point;
					
					GameObject building = Instantiate(BuildingManager.instance.storeHouse);
					print (BuildingManager.instance);
					building.transform.position = pos;
					
					SetBuildingPositionController.instance.building = building;
				}
			} 
			catch(Exception e){
				Debug.LogError(e);
			}
		} else{
			SetBuildingPositionController.instance.building = null;
		}
	}
}