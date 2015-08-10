using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResidentialBuilding : Building {

	public Vector2 spawnPosition;		//Position relative to the center of the house
	public GameObject[] inhabitants;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	public override void finishBuilding(){
		//Spawn new Inhabitants
		for(int i=0; i<inhabitants.Length; i++){
			inhabitants[i] = Instantiate(BuildingManager.instance.woodenHouse);
			inhabitants[i].transform.parent = transform;

			float x = spawnPosition.x + transform.position.x;
			float z = spawnPosition.y + transform.position.z;
			float y = Terrain.activeTerrain.terrainData.GetHeight((int)(x/4), (int)(z/4));
			inhabitants[i].transform.position = new Vector3(x, y, z);
		}
	}
}
