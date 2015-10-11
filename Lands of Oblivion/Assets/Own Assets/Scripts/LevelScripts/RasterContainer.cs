using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class RasterContainer
{
    public List<GameObject> list { get { return new List<GameObject>(list); } private set { list = value; } }

    public RasterContainer(List<GameObject> list)
    {
        this.list = new List<GameObject>();

        foreach (GameObject tempObj in list)
        {
            this.list.Add(tempObj);
        }
    }

    public RasterContainer(GameObject obj)
    {
        this.list = new List<GameObject>();
        this.list.Add(obj);
    }

    public RasterContainer()
    {
        this.list = new List<GameObject>();
    }

    public Boolean add(GameObject obj)
    {
        if (!this.list.Contains(obj) && obj.)
        {
            this.list.Add(obj);
            return true;
        }
        else
        {
            return false;
        }
    }

}