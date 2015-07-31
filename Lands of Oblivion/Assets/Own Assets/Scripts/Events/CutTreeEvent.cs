using UnityEngine;
using System;
using System.Collections;

public class CutTreeEvent : UserEvent {
	
	public void execute(){
		//Test for a tree in front of the player with a raycast 
		RaycastHit hit = RayCastManager.startRayCast(2);

		//Remove a tree if the player forward of one
		try{
			GameObject tree = hit.collider.gameObject.transform.parent.gameObject;
			if(tree.tag == "Tree"){
				tree.GetComponent<TreeControler>().removeLife();
			}
		}
		catch(NullReferenceException e){
			Debug.LogError("You should click on a tree if you want to cut one!");
		}
	}
}
