using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



class Chunk
{
    public static long counter = 0;
    private List<GameObject> prvList;

    public List<GameObject> list { get { return new List<GameObject>(prvList); } }

    public Chunk(List<GameObject> list)
    {
        counter++;
        this.prvList= new List<GameObject>();

        foreach (GameObject tempObj in list)
        {
            this.add(tempObj);
        }
    }

    public static long getCounter()
    {
        return counter;
    }

    public Chunk(GameObject obj)
    {
        counter++;
        this.prvList = new List<GameObject>();
        this.add(obj);
    }

    public Chunk()
    {
        counter++;
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