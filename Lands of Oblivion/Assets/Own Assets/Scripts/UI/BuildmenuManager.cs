using UnityEngine;
using System.Collections;

public class BuildmenuManager : MonoBehaviour {

	public void selectBuilding(string building){
		InputManager.instance.switchToMenu(InputManager.instance.buildmenuCanvas, false);
		BuildingManager.instance.selectedBuilding = building;
	}
}
