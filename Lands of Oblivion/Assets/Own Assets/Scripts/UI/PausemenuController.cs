using UnityEngine;
using System.Collections;

public class PausemenuController : MonoBehaviour {

	public void continueGame(){
		InputManager.instance.switchToMenu(InputManager.instance.pausemenuPanel, false, true);
        InputManager.instance.toggleTimeScale();
    }

	public void startmenu(){
		Application.LoadLevel("Startmenu");
	}

	public void closeGame(){
		Application.Quit();
	}

    public void options()
    {

    }
}
