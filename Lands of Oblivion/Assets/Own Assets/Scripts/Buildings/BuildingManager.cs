using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public static BuildingManager instance;

	public Building selectedBuilding = null;		//Bulding which the player wants to build


	public void Start(){
		instance = this;
	}
}
