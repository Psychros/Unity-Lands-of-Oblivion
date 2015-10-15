using UnityEngine;
using System;
using System.Collections;

public class CutTreeEvent : UserEvent {
	
	public void execute(){
		//Test for a tree in front of the player with a raycast 
		RaycastHit hit = RayCastManager.startRayCast(2);

		//Remove a tree if the player forward of one
	    GameObject tree = hit.collider.gameObject.transform.parent.gameObject;
        if(hit.collider != null && tree.tag == "Tree"){
		    tree.GetComponent<TreeControler>().removeLife();
		}
		
	}
}
