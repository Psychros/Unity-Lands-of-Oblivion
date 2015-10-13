using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TerrainEditor : MonoBehaviour {

	public static TerrainEditor instance = null;
	public Text currentHeight;
	public Text selectedHeight;
	public int selectedTerrainHeight = 13;
	public int maxHeight = 30;
	public int minHeight = 11;

	private Terrain terrain;
	public Terrain Terrain{
		get{return terrain;}
		set{terrain = value;}
	}

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(terrain != null){
			//Shows the current TerrainHeight at the selected point
			RaycastHit hit = RayCastManager.startRayCast(10f);

			try{
				if(hit.collider.transform.gameObject.tag == "Terrain")
					currentHeight.text = "" + hit.point.y;
			} catch(NullReferenceException e){
				currentHeight.text = "0";
			}
		}
	}
}
