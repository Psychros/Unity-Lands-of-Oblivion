using UnityEngine;
using System;
using System.Collections;

public class BuildBuildingEvent : UserEvent {

	private static GameObject building;

	public void execute(){
		if(SetBuildingPositionController.instance.building == null)
		{
			//Get the position where the player is looking at the terrain
			RaycastHit hit = RayCastManager.startRayCast(50);
			
			
			//Buildings can only be build on terrains
			try{
				if(hit.transform.gameObject.tag == "Terrain"){		
					building = createSelectedBuilding();
					building.transform.position = hit.point;


					enableColliders(false);
					SetBuildingPositionController.instance.building = building;
				}
			} 
			catch(Exception e){
				Debug.LogError("No building selected!");
			}
		} else
		{
			SetBuildingPositionController.instance.building = null;

			if(building != null){
				enableColliders(true);
				adjustTerrain(building);
				building.GetComponent<Building>().build();
			}
		}
	}


	//Adjust the terrain under the building
	private void adjustTerrain(GameObject building){

	}

	//Enable/Disable the colliders of the building
	private void enableColliders(bool b){
		Collider[] colliders = building.GetComponentsInChildren<Collider>();
		foreach(Collider collider in colliders){
			collider.enabled = b;
		}
	}


	public GameObject createSelectedBuilding(){
		GameObject building = null;

		switch(BuildingManager.instance.selectedBuilding){
			//Stores
			case "storehouse": 	 	 building = Instantiate(BuildingManager.instance.storeHouse); break;

			//Houses	
			case "farmhouse":	 	 building = Instantiate(BuildingManager.instance.woodenHouse); break;
			case "citizensHouse":	 building = Instantiate(BuildingManager.instance.woodenHouse); break;
			case "merchantsHouse":   building = Instantiate(BuildingManager.instance.woodenHouse); break;
			case "nobleVilla": 		 building = Instantiate(BuildingManager.instance.woodenHouse); break;

			//Food buildings
			case "fisher": 			 building = Instantiate(BuildingManager.instance.fisher); break;

			//Work buildings
			case "woodcutter":  	 building = Instantiate(BuildingManager.instance.woodcutter); break;

			//Civil buildings
			case "church":  		 building = Instantiate(BuildingManager.instance.church); break;
		}

		return building;
	}
}