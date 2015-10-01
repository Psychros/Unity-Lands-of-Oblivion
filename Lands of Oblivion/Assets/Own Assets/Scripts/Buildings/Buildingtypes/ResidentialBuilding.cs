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
			inhabitants[i] = Instantiate(NPCManager.instance.humanModel);

			float x = spawnPosition.x + transform.position.x;
			float z = spawnPosition.y + transform.position.z;
			float y = InputManager.instance.terrain.SampleHeight(new Vector3(x, 0, z));
			inhabitants[i].transform.position = new Vector3(x, y, z);

			inhabitants[i].transform.parent = transform;

		}
	}
}
