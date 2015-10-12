using UnityEngine;
using System.Collections;

public class TerrainEditor : MonoBehaviour {

	public static TerrainEditor instance = null;
	public Terrain terrain;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(terrain != null){

		}
	}
}
