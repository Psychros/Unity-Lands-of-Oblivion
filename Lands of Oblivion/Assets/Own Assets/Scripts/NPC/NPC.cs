using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	private NavMeshAgent nav = null;

	// Use this for initialization
	void Start () {
		NPCManager.instance.addPeople(1);
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!nav.hasPath)
			calculateRandomDestination();
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
		
		nav.SetDestination(new Vector3(x, y, z));
	}

}
