using UnityEngine;
using System.Collections;

public abstract class UserEvent : MonoBehaviour {

	//Start event
	public virtual void execute(){
		Debug.Log("Hello");
	}
}
