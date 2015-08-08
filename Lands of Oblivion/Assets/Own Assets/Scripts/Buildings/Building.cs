using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	float time = 5;
	float distance = 0;
	float startHeight;
	Vector3 pos;

	bool isInBuildProcess = false;

	// Use this for initialization
	void Start () {

	}

	//Build the building
	public void Update(){
		moveBuilding();
	}

	public virtual void build(){
		BoxCollider collider = gameObject.GetComponent<BoxCollider>();
		distance = collider.size.y/time;
		
		pos = gameObject.transform.position;
		startHeight = pos.y;
		transform.position = new Vector3(pos.x, pos.y-collider.size.y, pos.z);

		isInBuildProcess = true;
	}

	public virtual void finishBuilding(){

	}

	public void moveBuilding(){
		if(isInBuildProcess){
			if(transform.position.y < startHeight){

				transform.position = new Vector3(pos.x, transform.position.y + distance * Time.deltaTime, pos.z);
			} else{
				isInBuildProcess = false;
			}
		}
	}
}
