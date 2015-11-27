using UnityEngine;
using System.Collections;

public class BuildmenuManager : MonoBehaviour {
	public static BuildmenuManager instance;
	public GameObject activeMenu = null;

	void Start () {
		instance = this;
	}

	public void selectBuilding(string building){
		if(activeMenu != null){
			InputManager.instance.switchToMenu(activeMenu, false, true);
			activeMenu = null;
		} else{
			InputManager.instance.switchToMenu(InputManager.instance.buildmenuPanel, false, true);
		}

		BuildingManager.instance.selectedBuilding = building;
	}


	public void switchToSubmenu(GameObject subMenu){
		//Disable old menu
		if(activeMenu == null)
			InputManager.instance.buildmenuPanel.GetComponent<Canvas>().enabled = false;
		else
			activeMenu.GetComponent<Canvas>().enabled = false;

		subMenu.GetComponent<Canvas>().enabled   = true;
		this.activeMenu = subMenu;
		InputManager.instance.CurrentMenu = activeMenu;
	}


	public void switchToRootmenu(GameObject rootMenu){	
		activeMenu.SetActive(false);
        rootMenu.SetActive(true);
        activeMenu = rootMenu;
		InputManager.instance.CurrentMenu = activeMenu;
	}
}
