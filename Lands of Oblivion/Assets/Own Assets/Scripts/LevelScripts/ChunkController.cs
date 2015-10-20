using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ChunkController : MonoBehaviour {
    public Transform playerTransform;
    public Terrain terrain;
    public GameObject staticObjects;

    private LevelGrid grid;
    private Chunk[] displayedChunks; 

	// Use this for initialization
	void Start () {
        this.grid = new LevelGrid(terrain);
        initGrid(staticObjects);
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
        System.Object[] unusedChunks = Util.getDifferences(displayedChunks, chunks);

        if (unusedChunks != null)
        {
            if (unusedChunks.Length > 0)
            {
                foreach (Chunk actChunk in unusedChunks)
                {
                    if (actChunk != null)
                    {
                        foreach (GameObject obj in actChunk.list)
                        {
                            obj.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        count++;
        if (this.grid == null) return;
        Vector3 vec = playerTransform.position;

        Chunk[] chunks = this.grid.getComponentsOfChunk(vec.x, vec.z);

        enableNewChunks(chunks);
        disableUnusedChunks(chunks);

        this.displayedChunks = chunks;
    }
}
