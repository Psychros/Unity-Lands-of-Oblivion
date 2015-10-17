using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



class Chunk
{
    private List<GameObject> prvList;

    public List<GameObject> list { get { return new List<GameObject>(prvList); } }

    public Chunk(List<GameObject> list)
    {
        this.prvList= new List<GameObject>();

        foreach (GameObject tempObj in list)
        {
            this.add(tempObj);
        }
    }

    public Chunk(GameObject obj)
    {
        this.prvList = new List<GameObject>();
        this.add(obj);
    }

    public Chunk()
    {
        this.prvList = new List<GameObject>();
    }

    public Boolean add(GameObject obj)
    {
        if (!this.prvList.Contains(obj))
        {
            this.prvList.Add(obj);
            return true;
        }
        
	    return false;
    }
}