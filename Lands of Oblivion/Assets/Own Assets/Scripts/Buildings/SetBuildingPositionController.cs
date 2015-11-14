using UnityEngine;
using System.Collections;

public class SetBuildingPositionController : MonoBehaviour {

	public static SetBuildingPositionController instance;
	public GameObject building = null;
	public Building buildingScript = null;

    private float toleranceValue = 0.007f;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        //The building follows the mouse
        if (building != null)
        {
            Vector3 pos = RayCastManager.getTerrainPosition(200, buildingScript.minHeight, buildingScript.maxHeight);

            //Vector3.zero is the return value of RayCastManager.getTerrainPosition if there is no value
            if (pos != Vector3.zero & pos.y == BuildBuildingEvent.START_HEIGHT)
            {
                building.transform.position = new Vector3(pos.x, BuildBuildingEvent.START_HEIGHT, pos.z);
            }

            if (testTerrainForFlatness(pos)) {
                building.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
		}
	}

    bool testTerrainForFlatness(Vector3 v)
    {
        Renderer[] renderer = building.GetComponentsInChildren<Renderer>();
        Vector3 buildingPos = Math.translateVector3ToTerrainCoordinate(v, Terrain.activeTerrain);
        float height = Math.translateHeightToTerrainHeight(Terrain.activeTerrain.terrainData.GetHeight((int)buildingPos.x, (int)buildingPos.z), Terrain.activeTerrain);


        //Test all objects of the building
        foreach (Renderer r in renderer)
        {
            Vector3 pos = Math.translateVector3ToTerrainCoordinate(r.bounds.center, Terrain.activeTerrain);
            Vector3 size = Math.translateVector3ToTerrainCoordinate(r.bounds.size, Terrain.activeTerrain);

            //Test the heights of the heightmap for equwality
            int xPos = Math.round(pos.x - (size.x / 2));
            int zPos = Math.round(pos.z - (size.z / 2));

            //The building must be within the terrainborders
            if (xPos > 0 && zPos > 0 && (xPos + (size.x / 2)) < Terrain.activeTerrain.terrainData.size.x && (zPos + (size.z / 2)) < Terrain.activeTerrain.terrainData.size.z)
            {
                float[,] heightmap = Terrain.activeTerrain.terrainData.GetHeights(xPos, zPos, Math.round(size.x), Math.round(size.z));
                for (int x = 0; x < heightmap.GetLength(0); x++)
                {
                    for (int z = 0; z < heightmap.GetLength(1); z++)
                    {
                        float delta = Math.delta(height, heightmap[x, z]);
                        if (delta > toleranceValue)
                        {
                            return false;
                        }
                    }
                }
            }
        }


        return true;
    }
}
