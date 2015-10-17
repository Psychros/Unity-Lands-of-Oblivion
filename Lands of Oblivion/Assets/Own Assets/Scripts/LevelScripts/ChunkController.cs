using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ChunkController : MonoBehaviour {
    private LevelGrid grid;
    private GameObject player;
    private Chunk[] displayedChunks;
    private Boolean initialized = false;

	// Use this for initialization
	void Start () {
        try
        {
            this.grid = new LevelGrid(GameObject.Find("Terrain").GetComponent<Terrain>());
            this.player = GameObject.Find(Constants.NamePlayer);
        } catch (Exception e)
        {
            Debug.Log("Fatal error occured: " + e.Message + "\nGo to hell.");
        }
        initGrid(GameObject.Find(Constants.NameStaticGameObjectsContainer));
        initialized = true;
	}

    
    private void initGrid(GameObject actObj)
    {
        if (actObj.GetComponent<MeshFilter>() != null)
        {
            int x = Math.floatToGridColumn(actObj.transform.position.x, grid.widthRect);
            int y = Math.floatToGridRow(actObj.transform.position.y, grid.heightRect);

            this.grid.add(x, y, actObj);
            actObj.SetActive(false);
        }


        foreach (Transform trans in actObj.transform)
        {
            initGrid(trans.gameObject);
        }
    }

    private void enableNewChunks(Chunk[] chunks)
    {
        foreach (Chunk chunk in chunks)
        {
            if (chunk != null)
            {
                foreach (GameObject obj in chunk.list)
                {
                    if (!obj.activeInHierarchy) obj.SetActive(true);
                }
            }
        }
    }

    private void disableUnusedChunks(Chunk[] chunks)
    {
        foreach (Chunk tempChunk in chunks)
        {
            if (!Util.contains<Chunk, Chunk>(tempChunk, displayedChunks) && tempChunk != null)
            {
                foreach(GameObject obj in tempChunk.list)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (initialized == false) return;
        Vector3 vec = player.transform.position;

        Chunk[] chunks = this.grid.getComponentsOfChunk(vec.x, vec.y);

        enableNewChunks(chunks);
        disableUnusedChunks(chunks);

        this.displayedChunks = chunks;
    }
}
