using UnityEngine;
using System.Collections;

public class PausemenuController : MonoBehaviour {

	public void continueGame(){
		InputManager.instance.switchToMenu(InputManager.instance.pausemenuPanel, false, true);
	}

	public void startmenu(){
		Application.LoadLevel("Startmenu");
	}

	public void quitGame(){
		Application.Quit();
	}
}
