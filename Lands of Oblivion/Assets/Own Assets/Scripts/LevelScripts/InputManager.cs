using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance = null;

	public Transform playerTransform = null;

	//All KeyCodes
	public KeyCode cutTree = KeyCode.Mouse0;
	public KeyCode placeBuilding = KeyCode.Mouse1;


	
	void Start () {
		instance = this;
	}
	

	void Update () {
		//CutTree
		if(Input.GetKeyDown(cutTree)){
			CutTreeEvent userEvent = new CutTreeEvent();
			userEvent.execute();
		}
		//Place Building
		if(Input.GetKeyDown(placeBuilding)){
			if(SetBuildingPositionController.instance.building == null){
				BuildBuildingEvent userEvent = new BuildBuildingEvent();
				userEvent.execute();
			}
		}
	}
}