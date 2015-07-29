using UnityEngine;
using System.Collections;
using System;

public class GlobalStore : MonoBehaviour {

	public GlobalStore instance;

	private int[]ressources = new int[300];   //Number of ressources
	public int storeSize = 10;			      //Size of store



	public int getNumberOfRessource(Ressources id) {
		return ressources[(int)id];
	}

	public int getNumberOfRessource(int id) {
		return ressources[id];
	}
}
