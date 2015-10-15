using UnityEngine;
using System.Collections;

public class Math : MonoBehaviour
{
	public static Vector3 translateVector3ToTerrainCoordinate(Vector3 v, Terrain terrain){
		Vector3 pos = (v - terrain.transform.position) * terrain.terrainData.heightmapResolution;
		pos.x /= terrain.terrainData.size.x;
		pos.y /= terrain.terrainData.size.y;
		pos.z /= terrain.terrainData.size.z;

		return pos;
	}

	public static float translateHeightToTerrainHeight(float height, Terrain terrain){
		return height/terrain.terrainData.size.y;
	}

    public static int floatToGridColumn(float x, float widthGridUnit)
    {
        return (int)(x / widthGridUnit);
    }

    public static int floatToGridRow(float y, float heightGridUnit)
    {
        return (int)(y / heightGridUnit);
    }
}

