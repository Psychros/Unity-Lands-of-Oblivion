using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ChunkController : MonoBehaviour {
    LevelGrid grid;
    GameObject player;
    Chunk[] displayedChunks;

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
            int y = Math.floatToGridRow(actObj.transform.position.y, grid.heightRect);

            this.grid.add(x, y, actObj);
            actObj.SetActive(false);
        }


        foreach (Transform trans in actObj.transform)
        {
            initGrid(trans.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 vec = player.transform.position;

        List<GameObject>[] comps = this.grid.getComponentsOfChunk(vec.x, vec.y);

        foreach(List<GameObject> list in comps)
        {
            if (list == null) continue;
            foreach(GameObject obj in list)
            {
                if (!obj.activeInHierarchy) obj.SetActive(true);
            }
        }

	    //update Meshs
	}
}
