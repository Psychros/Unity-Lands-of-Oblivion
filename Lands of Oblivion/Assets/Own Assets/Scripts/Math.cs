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
}

