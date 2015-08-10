using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public static BuildingManager instance;

	public string selectedBuilding = null;		//Bulding which the player wants to build

	//All Building Prefabs
	public GameObject storeHouse;
	public GameObject woodenHouse;


	public void Start(){
		instance = this;
	}
}
