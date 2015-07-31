using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public static BuildingManager instance;
	public GameObject buildings;

	//All Building Prefabs
	public GameObject storeHouse;


	public void Start(){
		instance = this;
	}
}
