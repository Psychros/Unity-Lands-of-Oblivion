using UnityEngine;
using System.Collections;

public class NPC : Pathfinding {
	public WorkBuilding workPlace = null;

	// Use this for initialization
	void Start () {
		NPCManager.instance.addNPC(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Path.Count == 0 && workPlace == null){
			calculateRandomDestination();
		}

		//Is only executed if the npc is refered to a workBuilding an lets the workBuilding work
		else if(workPlace != null && Vector3.Distance(transform.position, workPlace.transform.position) < 0.5f){	//Is the NPC at the workplace?
			workPlace.worker = gameObject;
			this.enabled = false;
		}

        if(Path.Count > 0)
            Move();
	}


	//Calculates a random path
	public void calculateRandomDestination(){
		Terrain terrain = InputManager.instance.terrain;

		float x = 0;
		float y = 0;
		float z = 0;

		while(y<10){
			x = (int)Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
			z = (int)Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);
		    y = terrain.SampleHeight(new Vector3(x, 0, z));
		}
		
		FindPath(transform.position, new Vector3(x, y, z));
	}
}
