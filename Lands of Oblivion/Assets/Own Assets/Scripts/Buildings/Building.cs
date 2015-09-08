using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Building : MonoBehaviour {

	float time = 0;
	float timer = 0;
	float speed = 0;
	float startHeight;
	bool haveEnoughRessources = false;
	Vector3 pos;
	bool isInBuildProcess = false;

	public List<Cost> costs = new List<Cost>();
	public float buildingtimeForOneRessource = 3;		//Time in seconds



	// Use this for initialization
	void Start () {
		timer = buildingtimeForOneRessource;
	}
	

	//Build the building
	public void Update(){
		moveBuilding();
	}

	public virtual void build(){
		BoxCollider collider = gameObject.GetComponent<BoxCollider>();
		
		pos = gameObject.transform.position;
		startHeight = pos.y;
		transform.position = new Vector3(pos.x, pos.y-collider.size.z, pos.z);

		isInBuildProcess = true;

		//Calculate the time
		foreach(Cost cost in costs){
			time += cost.number * buildingtimeForOneRessource;
		}

		//Calculate the buildspeed
		speed = collider.size.z/time;
	}

	public virtual void finishBuilding(){

	}

	public void moveBuilding(){
		if(isInBuildProcess){
			if(transform.position.y < startHeight){
				payRessources();

				if(haveEnoughRessources)
					transform.position = new Vector3(pos.x, transform.position.y + speed * Time.deltaTime, pos.z);
			} else{
				//Finish the build process
				isInBuildProcess = false;
				finishBuilding();
			}
		}
	}


	//Every timeForOneRessource seconds one ressource is been payed
	//If no ressources are in the store, the building process stops
	public void payRessources(){
		//Remove ressources
		if(timer >= buildingtimeForOneRessource && costs.Capacity > 0){
			if(GlobalStore.instance.getNumberOfRessource((int)costs[0].ressource) > 0){
				GlobalStore.instance.addRessources(costs[0].ressource,-1);
				Cost c = costs[0];
				c.number++;
				costs[0] = c;
				
				//Switch to the next ressource
				if(costs[0].number == 0){
					costs.RemoveAt(0);
					costs.TrimExcess();
				}

				haveEnoughRessources = true;
				timer = 0;
			} else {
				haveEnoughRessources = false;
			}
		} 

		timer += Time.deltaTime;
	}
}
