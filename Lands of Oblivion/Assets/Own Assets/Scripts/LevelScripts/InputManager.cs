using UnityEngine;
using UnityEngine.UI;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance = null;

	public Transform playerTransform = null;
	public Terrain terrain;
	public GameObject ui;
	public  bool isMenu = false;
	public Canvas currentMenu;
	private bool isPause = false;

	//All menupanels
	public Canvas inGameCanvas;
	public Canvas buildmenuCanvas;
	public Canvas pausemenuCanvas;
	public Canvas storemenuCanvas;

	//All KeyCodes
	public KeyCode cutTree			 = KeyCode.Mouse0;
	public KeyCode placeBuilding 	 = KeyCode.Mouse1;
	public KeyCode stopPlaceBuilding = KeyCode.Mouse0;

	public KeyCode buildmenu 		 = KeyCode.F;
	public KeyCode pausemenu 		 = KeyCode.Escape;
	public KeyCode storemenu 		 = KeyCode.Tab;


	
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

		//Buildmenu
		if(Input.GetKeyDown(buildmenu)){
			switchToMenu(buildmenuCanvas, false);
			if(isMenu){
				BuildmenuManager.instance.activeMenu = null;
			}
		}

		//Pausemenu
		if(Input.GetKeyDown(pausemenu)){
			switchToMenu(pausemenuCanvas, false);
			toggleTimeScale();
		}

		//Storemenu
		if(Input.GetKeyDown(storemenu)){
			switchToMenu(storemenuCanvas, false);
		}
	}


	public void toggleTimeScale(){
		isPause = !isPause;

		if(isPause){
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void switchToMenu(Canvas menu, bool showInGame){
		isMenu = !isMenu;
		if(isMenu){
			if(!showInGame)
				inGameCanvas.enabled = false;

			menu.enabled = true;
			currentMenu = menu;
			
		} else {
			inGameCanvas.enabled = true;
			currentMenu.enabled = false;
			currentMenu = null;
		}
	}
}