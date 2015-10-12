using UnityEngine;
using System.Collections;
using System;

public class ChunkController : MonoBehaviour {
    LevelGrid grid;
    GameObject player;

	// Use this for initialization
	void Start () {
        try
        {
            this.grid = new LevelGrid(GameObject.Find("Terrain").GetComponent<Terrain>());
            this.player = GameObject.Find(Constants.NamePlayer);
        } catch (Exception e)
        {
            Debug.Log("Fatal error Occurred while trying to load data");
        }

        //deleteAllMeshs();
	}
	
	// Update is called once per frame
	void Update () {
	    //update Meshs
	}
}
