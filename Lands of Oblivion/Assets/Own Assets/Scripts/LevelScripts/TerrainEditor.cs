using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class TerrainEditor : MonoBehaviour {

	public static TerrainEditor instance { get; private set; }
	public Text currentHeight;
	public Text selectedHeight;
	public int selectedTerrainHeight = 13;
	public int maxHeight = 30;
	public int minHeight = 11;
	public GameObject wireframeCubePrefab;
    public float editSpeed = 0.01f;

	private Terrain terrain;
	public Terrain Terrain{
		get{return terrain;}
		set{terrain = value;}
	}

	private Vector3 pos;
    private float dirt = 0;             //Dirt is needed for raising up the terrain
	private bool canEditTerrain = false;
	private GameObject cube = null;


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
		if(canEditTerrain && cube != null){
			cube.transform.position = pos;
		}
	}

	public void activateTerrainEditor(){
		terrain = Terrain.activeTerrain;
		cube = Instantiate(wireframeCubePrefab);
	}

	public void deactivateTerrainEditor(){
		terrain = null;
		Destroy(cube);
		cube = null;
	}

	public void editTerrain(){
		Vector3 terrainPosition = Math.translateVector3ToTerrainCoordinate(pos, terrain);
		float[,] height = new float[1, 1];
        height[0, 0] = terrain.terrainData.GetHeight(Math.round(terrainPosition.x), Math.round(terrainPosition.z));
        height[0, 0] = Math.translateHeightToTerrainHeight(height[0, 0], terrain);
        float newHeight = Math.translateHeightToTerrainHeight(selectedTerrainHeight, terrain);

        //Sink the terrain
        if (height[0, 0] > newHeight)
        {
            height[0, 0] -= Math.translateHeightToTerrainHeight(Time.deltaTime * editSpeed, terrain);

            if (height[0, 0] < newHeight)
            {
                height[0, 0] = newHeight;
            }
        }
        //Raise the terrain
        else if (height[0, 0] < newHeight)
        {
            height[0, 0] += Math.translateHeightToTerrainHeight(Time.deltaTime * editSpeed, terrain);
            print("Hallo");

            if (height[0, 0] > newHeight)
            {
                height[0, 0] = newHeight;
            }
        }

        terrain.terrainData.SetHeightsDelayLOD(Math.round(terrainPosition.x), Math.round(terrainPosition.z), height);
        Pathfinder.Instance.editNode(Math.round(terrainPosition.x), Math.round(terrainPosition.z));
	}

    public void stopEditing()
    {
        terrain.ApplyDelayedHeightmapModification();
    }

	public void editSelectedHeight(int value){
		selectedTerrainHeight += value;
		selectedHeight.text = "" + TerrainEditor.instance.selectedTerrainHeight;
	}
}
