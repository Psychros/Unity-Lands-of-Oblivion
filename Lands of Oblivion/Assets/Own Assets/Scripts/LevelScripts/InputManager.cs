using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance = null;

	public Transform playerTransform = null;

	//All KeyCodes
	public KeyCode cutTree = KeyCode.Mouse0;
	public KeyCode placeBuilding = KeyCode.Mouse1;
	public KeyCode stopPlaceBuilding = KeyCode.Mouse0;


	
	void Start () {
		instance = this;
	}
	

	void Update () {
		//Cut tree
		if(Input.GetKeyDown(cutTree)){
			CutTreeEvent userEvent = new CutTreeEvent();
			userEvent.execute();
		}

		//Place building
		if(Input.GetKeyDown(placeBuilding)){
			BuildBuildingEvent userEvent = new BuildBuildingEvent();
			userEvent.execute();
		}

		//Stop place building
		if(Input.GetKeyDown(stopPlaceBuilding)){
			//Destroy the building which the player is placing
			Destroy(SetBuildingPositionController.instance.building);
			SetBuildingPositionController.instance.building = null;
		}
	}
}