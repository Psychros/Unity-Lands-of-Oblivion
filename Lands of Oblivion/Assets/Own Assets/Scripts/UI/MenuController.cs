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

	public void setLanguageKey(string key){
		Localizer.Instance.LoadLocalizationFile(key);

		LocalizeText[] texts = FindObjectsOfType<LocalizeText>();
		foreach(LocalizeText text in texts){
			text.Start();
		}
	}
}
