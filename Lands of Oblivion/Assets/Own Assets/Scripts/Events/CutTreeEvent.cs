using UnityEngine;
using System;
using System.Collections;

public class CutTreeEvent : UserEvent {
	
	public void execute(){
		//Test for a tree in front of the player with a raycast 
		RaycastHit hit = RayCastManager.startRayCast(2);

        //Remove a tree if the player forward of one
        Collider coll = hit.collider;
        if (coll != null) {

            GameObject hitObj = coll.transform.parent.gameObject;

            if(hitObj.tag == "Tree"){
	            hitObj.GetComponent<TreeControler>().removeLife();
		    }
        }
	}
}
