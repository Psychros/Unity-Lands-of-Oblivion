using UnityEngine;
using System.Collections;

public class PausemenuController : MonoBehaviour {

	public void continueGame(){
		InputManager.instance.switchToMenu(InputManager.instance.pausemenuCanvas, false);
	}

	public void startmenu(){
		Application.LoadLevel("Startmenu");
	}

	public void quitGame(){
		Application.Quit();
	}
}
