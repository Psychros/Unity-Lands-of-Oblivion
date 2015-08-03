using UnityEngine;
using System;
using System.Collections;

public class BuildBuildingEvent : UserEvent {

	private static GameObject building;

	public void execute(){
		if(SetBuildingPositionController.instance.building == null){
			//Get the position where the player is looking at the terrain
			RaycastHit hit = RayCastManager.startRayCast(50);
			
			
			//Buildings can only be build on terrains
			try{
				if(hit.transform.gameObject.tag == "Terrain"){
					Vector3 pos = hit.point;
					
					building = Instantiate(BuildingManager.instance.storeHouse);
					building.transform.position = pos;

					SetBuildingPositionController.instance.building = building;
				}
			} 
			catch(Exception e){
				Debug.LogError(e);
			}
		} else{
			SetBuildingPositionController.instance.building = null;

			if(building != null)
				adjustTerrain(building);
		}
	}


	//Adjust the terrain under the building
	private void adjustTerrain(GameObject building){
		TerrainData data = Terrain.activeTerrain.terrainData;
		BoxCollider collider = building.GetComponent<BoxCollider>();
		Vector3 pos = collider.transform.position;
		Vector3 size = collider.size;

		print (pos.x + ", " + pos.z);
		int x = (int)(pos.x/4);	
		int z = (int)(pos.z-(size.z/4));	
		float[,] area = new float[(int)(size.z), (int)(size.x)];

		//Fill the are with the height of the building
		for(int i=0; i<area.GetLength(0); i++){
			for(int j=0; j<area.GetLength(1); j++){
				area[i, j] = pos.y/200;
			}
		}

		//Make the change visible
		data.SetHeights(x/4, z/4, area);
	}
}