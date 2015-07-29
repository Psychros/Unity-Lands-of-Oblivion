using UnityEngine;
using System.Collections;
using System;

public class CutTreeEvent : UserEvent {
	
	public void execute(){
		//Test for a tree in front of the player with a raycast 
		RaycastHit hit;
		Vector3 direction = InputManager.instance.playerTransform.TransformDirection(Vector3.forward);
		Vector3 position = InputManager.instance.playerTransform.position;
		Physics.Raycast(position, direction, out hit, 2);

		//Remove tree
		try{
			GameObject tree = hit.collider.gameObject.transform.parent.gameObject;
			if(tree.tag == "Tree"){
				tree.GetComponent<TreeControler>().removeLife();
			}
		}
		catch(NullReferenceException e){
			Debug.LogError("You should click on a tree if you want to cut anyone!");
		}
	}
}
