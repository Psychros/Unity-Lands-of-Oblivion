using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	float time = 5;
	float distance = 0;
	float startHeight;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		BoxCollider collider = gameObject.GetComponent<BoxCollider>();
		distance = collider.size.y/time;

		pos = gameObject.transform.position;
		startHeight = pos.y;
		transform.position.Set(pos.x, pos.y-collider.size.y, pos.z);
	}

	//Build the building
	public void Update(){
		moveBuilding();
	}

	public virtual void build(){

	}

	public virtual void finishBuilding(){

	}

	public void moveBuilding(){
		print ("Start");
		if(transform.position.y < startHeight){
			transform.position.Set(pos.x, transform.position.y + distance * Time.deltaTime, pos.z);
		}
	}
}
