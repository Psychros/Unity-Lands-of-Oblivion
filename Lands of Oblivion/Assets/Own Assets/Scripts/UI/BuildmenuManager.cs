using UnityEngine;
using System.Collections;

public class BuildmenuManager : MonoBehaviour {

	public void selectBuilding(string building){
		BuildingManager.instance.selectedBuilding = building;

		InputManager.instance.switchToMenu(InputManager.instance.buildmenuCanvas, false);
	}
}
