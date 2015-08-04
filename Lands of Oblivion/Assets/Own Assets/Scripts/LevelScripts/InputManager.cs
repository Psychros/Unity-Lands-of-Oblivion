using UnityEngine;
using UnityEngine.UI;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance = null;

	public Transform playerTransform = null;
	public GameObject ui;

	//All menupanels
	public RectTransform panelBuildmenu;

	//All KeyCodes
	public KeyCode cutTree			 = KeyCode.Mouse0;
	public KeyCode placeBuilding 	 = KeyCode.Mouse1;
	public KeyCode stopPlaceBuilding = KeyCode.Mouse0;

	public KeyCode buildmenu 		 = KeyCode.F;


	
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

		//Open or close the buildmenu
		if(Input.GetKeyDown(buildmenu)){
			if(panelBuildmenu.parent != null)
				panelBuildmenu.parent = null;
			else
				panelBuildmenu.parent = ui.transform;
		}
	}
}