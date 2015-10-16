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
            Debug.Log("Fatal error occured: " + e.Message + "/nGo to hell.");
        }
        Debug.Log("Trying to init grid");
        initGrid(GameObject.Find(Constants.NameStaticGameObjectsContainer));
	}

    int temp = 0;
    private void initGrid(GameObject actObj)
    {
        Debug.Log(++temp);
        //Nö
        Mesh tempMesh = actObj.GetComponent<Mesh>();

        //Ebenfalls nö
        MeshFilter tempFilt = actObj.GetComponent<MeshFilter>();

        if (actObj.GetComponent<Mesh>() != null)
        {
            int x = Math.floatToGridColumn(actObj.transform.position.x, grid.widthRect);
            int y = Math.floatToGridRow(actObj.transform.position.y, grid.heightRect);

            this.grid.add(x, y, actObj);
        }

        foreach (Transform trans in actObj.transform)
        {
            initGrid(trans.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
	    //update Meshs
	}
}
