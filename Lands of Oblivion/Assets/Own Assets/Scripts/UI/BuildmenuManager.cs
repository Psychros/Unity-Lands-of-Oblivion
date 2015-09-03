using UnityEngine;
using System.Collections;

public class BuildmenuManager : MonoBehaviour {
	public Canvas activeMenu = null;

	public void selectBuilding(string building){
		if(activeMenu != null){
			InputManager.instance.switchToMenu(activeMenu, false);
			activeMenu = null;
		} else{
			InputManager.instance.switchToMenu(InputManager.instance.buildmenuCanvas, false);
		}

		BuildingManager.instance.selectedBuilding = building;
	}


	public void switchToSubmenu(Canvas subMenu){
		//Disable old menu
		if(activeMenu == null)
			InputManager.instance.buildmenuCanvas.GetComponent<Canvas>().enabled = false;
		else
			activeMenu.GetComponent<Canvas>().enabled = false;

		subMenu.GetComponent<Canvas>().enabled   = true;
		this.activeMenu = subMenu;
	}


	public void switchToRootmenu(Canvas rootMenu){	
		activeMenu.GetComponent<Canvas>().enabled = false;
		rootMenu.GetComponent<Canvas>().enabled = true;
		activeMenu = rootMenu;
	}
}
