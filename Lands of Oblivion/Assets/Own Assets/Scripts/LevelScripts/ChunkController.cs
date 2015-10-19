using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ChunkController : MonoBehaviour {
    private LevelGrid grid;
    private GameObject player;
    private Chunk[] displayedChunks;

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
	}

    
    private void initGrid(GameObject actObj)
    {
        if (actObj.GetComponent<MeshFilter>() != null)
        {
            int x = Math.floatToGridColumn(actObj.transform.position.x, grid.widthRect);
            int z = Math.floatToGridRow(actObj.transform.position.z, grid.heightRect);

            this.grid.add(x, z, actObj);
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
    long count = 0;
    private void disableUnusedChunks(Chunk[] chunks)
    {
        //if (count > 400)
        //{
        //    Debug.Log("titten");
        //    Debug.Log("doppeltitten");
        //}
        //Debug.Log(count);
        //foreach (Chunk tempChunk in chunks)
        //{
        //    if (!Util.contains<Chunk, Chunk>(tempChunk, displayedChunks) && tempChunk != null)
        //    {
        //        foreach(GameObject obj in tempChunk.list)
        //        {
        //            obj.SetActive(false);
        //        }
        //    }
        //}
        Chunk[] unusedChunks = Util.getDifferences<Chunk>(displayedChunks, chunks);
        if (unusedChunks != null)
        {
            if (unusedChunks.Length > 0)
            {
                Debug.Log("titten");
            }
        }
    }

    // Update is called once per frame
    void Update () {
        count++;
        if (this.grid == null) return;
        Vector3 vec = player.transform.position;

        Chunk[] chunks = this.grid.getComponentsOfChunk(vec.x, vec.z);

        enableNewChunks(chunks);
        disableUnusedChunks(chunks);

        this.displayedChunks = chunks;
    }
}
