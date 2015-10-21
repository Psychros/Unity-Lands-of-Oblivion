using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class LevelGrid{
    private const int MAXIMUM_SIZE_SQUARE = 75;
    private const int AMOUNT_CHUNKS_LOADED = 9;
    private readonly float width;
    private readonly float height;
    private readonly float absX;
    private readonly float absY;
    private readonly int rectsWidth;
    private readonly int rectsHeight;
    public float widthRect { get; private set; }
    public float heightRect { get; private set; }
    private Chunk[,] grid;

    public LevelGrid(float initX, float initY, float width, float height)
    {
        this.width = width;
        this.height = height;
        this.absX = initX;
        this.absY = initY;
        this.rectsWidth = calcRectsWidth(width);
        this.rectsHeight = calcRectsHeight(height);
        this.grid = new Chunk[rectsWidth, rectsHeight];
    }
    
    public LevelGrid(Terrain ter) : this(ter.transform.position.x,
                                         ter.transform.position.y,
                                         ter.terrainData.size.x  ,
                                         ter.terrainData.size.z  ){ }

    public Chunk[] getComponentsOfChunk(float x, float y)//, int chunks = 9) //TODO
    {
        int column = Math.floatToGridColumn(x - absX, widthRect);
        int row = Math.floatToGridRow(y - absY, heightRect);
        int i = 0;
        Chunk[] chunks = new Chunk[9];


        for (int j = -1; j < 2; j++)
        {
            if (column + j >= 0 && column + j < rectsWidth)
            {
                for (int k = -1; k < 2; k++)
                {
                    if (row + k >= 0 && row + k < rectsHeight)
                    {
                        Chunk tempChunk = grid[column + j, row + k];
                        if (tempChunk != null)
                        {
                            chunks[i++] = grid[column + j, row + k];
                        }
                    }
                }
            }
        }
        return chunks;
    }

    public Boolean add(int x, int y, GameObject addedGameObject)
    {
        if (x >= rectsWidth || y >= rectsHeight) throw new IllegalArgumentException("Object to be added is out of grid");
        Boolean returned = false;

        if (grid[x,y] == null)
        {
            grid[x, y] = new Chunk();
            returned = true;
        }
        grid[x, y].add(addedGameObject);

        return returned;
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

    private int calcRectsHeight(float totalHeight)
    {
        int divider = 0;
        this.heightRect = float.MaxValue;

        while (this.heightRect > MAXIMUM_SIZE_SQUARE)
        {
            divider++;
            this.heightRect = totalHeight / divider;
        }

        return divider;
    }


}

