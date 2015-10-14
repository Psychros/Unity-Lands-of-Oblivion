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
	public GameObject wireframeCubePrefab;

	private Terrain terrain;
	public Terrain Terrain{
		get{return terrain;}
		set{terrain = value;}
	}

	private Vector3 pos;
	private bool canEditTerrain = false;
	private GameObject wireframeCube = null;


	// Use this for initialization
	void Start () {
		instance = this;
		selectedHeight.text = "" + selectedTerrainHeight;
	}


	// Update is called once per frame
	void Update () {
		if(terrain != null){
			showCurrentTerrainHeight();
			setCubePosition();
		}
	}


	//Shows the current TerrainHeight at the selected point
	void showCurrentTerrainHeight(){
		Vector3 position = RayCastManager.getTerrainPosition(20);
		currentHeight.text = "" + position.y;
		pos = position;

		if(position.y >= minHeight && position.y <= maxHeight){
			canEditTerrain = true;
		} else {
			canEditTerrain = false;
		}
	}

	void setCubePosition(){
		if(canEditTerrain && wireframeCube != null){
			wireframeCube.transform.position = pos;
		}
	}

	public void activateTerrainEditor(){
		terrain = Terrain.activeTerrain;
		wireframeCube = Instantiate(wireframeCubePrefab);
	}

	public void deactivateTerrainEditor(){
		terrain = null;
		Destroy(wireframeCube);
		wireframeCube = null;
	}

	public void editTerrain(){
		Vector3 terrainPosition = Math.translateVector3ToTerrainCoordinate(pos, terrain);
		float[,] height = new float[1, 1];
		height[0, 0] = Math.translateHeightToTerrainHeight(selectedTerrainHeight, terrain);

		terrain.terrainData.SetHeights((int)terrainPosition.x, (int)terrainPosition.z, height);
	}
}
