using UnityEngine;
using System;
using System.Collections;

public class BuildBuildingEvent : UserEvent {

	private static GameObject building;

	public override void execute(){
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
					SetBuildingPositionController.instance.buildingScript = building.GetComponent<Building>();
				}
			} 
			catch(Exception e){
				Debug.LogError("No building selected! " + e.Message);
			}
		} else
		{
			SetBuildingPositionController.instance.building = null;
			SetBuildingPositionController.instance.buildingScript = null;

			if(building != null){
				enableColliders(true);
				adjustTerrain(building);
				building.GetComponent<Building>().build();
			}
		}
	}


	//Adjust the terrain under the building
	private void adjustTerrain(GameObject building){
		Terrain terrain = Terrain.activeTerrain;

		//Calculate length and width of the mesh in Terrain Coordinates
		Vector3 size = building.GetComponentInChildren<MeshRenderer>().bounds.size;
		size = Math.translateVector3ToTerrainCoordinate(size, Terrain.activeTerrain);
		float width = size.x;
		float length = size.z;

		//Translate the position in a Terrainposition
		Vector3 pos = Math.translateVector3ToTerrainCoordinate(building.transform.position, Terrain.activeTerrain);

		//Modify the heightmap
		float height = terrain.terrainData.GetHeight((int)(pos.x-width/2), (int)(pos.z-length/2));
		float[,] heightmap = terrain.terrainData.GetHeights((int)pos.x, (int)pos.z, (int)width, (int)length);
		for(int x=0; x<heightmap.GetLength(0); x++){
			for(int z=0; z<heightmap.GetLength(1); z++){
				heightmap[x, z] = height/terrain.terrainData.size.y;
			}
		}
		terrain.terrainData.SetHeights((int)(pos.x-width/2), (int)(pos.z-length/2), heightmap);
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