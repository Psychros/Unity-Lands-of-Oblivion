using UnityEngine;
using System.Collections;

public class SetBuildingPositionController : MonoBehaviour {

	public static SetBuildingPositionController instance;
	public GameObject building = null;
	public Building buildingScript = null;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        //The building follows the mouse
        if (building != null)
        {
            //if (testTerrainForFlatness()) { 
                Vector3 pos = RayCastManager.getTerrainPosition(200, buildingScript.minHeight, buildingScript.maxHeight);
                if (pos != Vector3.zero)
                    building.transform.position = pos;
            //}
		}
	}

    bool testTerrainForFlatness()
    {
        Renderer[] renderer = building.GetComponentsInChildren<Renderer>();
        float height = Math.translateHeightToTerrainHeight(building.transform.position.y, Terrain.activeTerrain);

        foreach (Renderer r in renderer)
        {
            Vector3 pos = Math.translateVector3ToTerrainCoordinate(r.bounds.center, Terrain.activeTerrain);
            Vector3 size = Math.translateVector3ToTerrainCoordinate(r.bounds.size, Terrain.activeTerrain);

            //Test the heights of the heightmap for equwality
            float[,] heightmap = Terrain.activeTerrain.terrainData.GetHeights(Math.round(pos.x - (size.x / 2)), Math.round(pos.z - (size.z / 2)), Math.round(size.x), Math.round(size.z));
            for (int x = 0; x < heightmap.GetLength(0); x++)
            {
                for (int z = 0; z < heightmap.GetLength(1); z++)
                {
                    if (heightmap[x, z] != height)
                    {
                        return false;
                    }
                }
            }
        }


        return true;
    }
}
