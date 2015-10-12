using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class LevelGrid{
    private const int MAXIMUM_SIZE_SQUARE = 75;
    private const int AMOUNT_CHUNKS_LOADED = 9;
    private readonly float width;
    private readonly float length;
    private readonly float absX;
    private readonly float absY;
    private float widthRect;
    private float lengthRect;
    private Chunk[,] grid;


 //   int x = e.getX();
 //   int y = e.getY();
 //   x = (x - UNBENUTZTEPIXELVONLINKS) / BREITERECHTECKE;
 //y = (y - UNBENUTZTEPIXELVONOBEN) / HÖHERECHTECKE;

    public LevelGrid(float initX, float initY, float width, float length)
    {
        this.width = width;
        this.length = length;
        this.absX = initX;
        this.absY = initY;
        this.grid = new Chunk[calcRectsWidth(width), calcRectsLength(length)];
        initGrid(GameObject.Find(Constants.NameStaticGameObjectsContainer));
    }
    
    public LevelGrid(Terrain ter) : this(ter.transform.position.x,
                                         ter.transform.position.y,
                                         ter.terrainData.size.x  ,
                                         ter.terrainData.size.y  ){ }

    public List<GameObject>[] getComponentsOfChunk(float x, float y)//, int chunks = 9) //TODO
    {
        int column = calcColumn(x);
        int row = calcRow(y);
        List<GameObject>[] array = new List<GameObject>[9];

        for(int i = 0; i < 9; i++)
        {
            for (int j = -1; j < 1; j++)
            {
                if (row + j < 0) continue;
                for (int k = -1; k < 1; k++)
                {
                    if (column + k < 0) continue;
                    array[i] = grid[column + j, row + k].list;
                }
            }
        }

        return array;
    }

    private void initGrid(GameObject actObj)
    {
        if (actObj.GetComponent<MeshFilter>().mesh != null)
        {
            int x = calcColumn(actObj.transform.position.x);
            int y = calcRow(actObj.transform.position.y);

            if (grid[x, y] == null)
            {
                grid[x, y] = new Chunk();
            }
            grid[x, y].add(actObj);
        }

        foreach (Transform trans in actObj.transform)
        {
            initGrid(trans.gameObject);
        }
    }

    private int calcColumn(float x)
    {
        return (int)(x / widthRect);
    }

    private int calcRow(float y)
    {
        return (int)(y / lengthRect);
    }


    private int calcRectsWidth(float totalWidth)
    {
        int divider = 0;
        this.widthRect = float.MaxValue;

        while (this.widthRect > MAXIMUM_SIZE_SQUARE)
        {
            divider++;
            this.widthRect = totalWidth / divider;
        }

        return divider;
    }

    private int calcRectsLength(float totalLength)
    {
        int divider = 0;
        this.lengthRect = float.MaxValue;

        while (this.lengthRect > MAXIMUM_SIZE_SQUARE)
        {
            divider++;
            this.lengthRect = totalLength / divider;
        }

        return divider;
    }


}

