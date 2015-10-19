using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



class Chunk : Identifyable
{
    private List<GameObject> prvList;
    public override long id { get; protected set; }
    private static long count = 0;

    public List<GameObject> list { get { return new List<GameObject>(prvList); } }

    public Chunk(List<GameObject> list)
    {
        this.prvList= new List<GameObject>();

        this.id = Chunk.count;
        Chunk.count++;

        foreach (GameObject tempObj in list)
        {
            this.add(tempObj);
        }
    }

    public Chunk(GameObject obj)
    {
        this.id = count;
        count++;
        this.prvList = new List<GameObject>();
        this.add(obj);
    }

    public Chunk()
    {
        this.id = count;
        count++;
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