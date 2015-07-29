using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void startGame() {
		Application.LoadLevel("Map");
	}
	
	public void options(){
		
	}
	
	public void quitGame(){
		Application.Quit();
	}
}
