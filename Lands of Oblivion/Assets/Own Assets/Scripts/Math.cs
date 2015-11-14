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

    public static float translateTerrainHeightToHeight(float terrainHeight, Terrain terrain)
    {
        return terrainHeight * terrain.terrainData.size.y;
    }


    public static int floatToGridColumn(float x, float widthGridUnit)
    {
        return (int)(x / widthGridUnit);
    }


    public static int floatToGridRow(float y, float heightGridUnit)
    {
        return (int)(y / heightGridUnit);
    }


	public static int round(float value){
		float decimalPlaces = value - (int)value;
		if(decimalPlaces >= 0.5f)
			return ((int) value + 1);
		else
			return (int) value;

	}


	public static Vector3 roundVector3(Vector3 v){
		int x = round (v.x);
		int y = round (v.y);
		int z = round (v.z);

		return new Vector3(x, y, z);
	}

    public static float delta(float x, float y)
    {
        if (x > y)
            return x - y;
        else
            return y - x;
    }
}

