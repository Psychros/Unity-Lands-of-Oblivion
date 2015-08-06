using UnityEngine;
using System.Collections;

public class BuildmenuManager : MonoBehaviour {

	public void selectBuilding(string building){
		BuildingManager.instance.selectedBuilding = building;

		InputManager.instance.isMenu = false;
		InputManager.instance.buildmenuCanvas.enabled = false;
	}
}
