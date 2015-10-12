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
    private readonly float terX;
    private readonly float terY;
    private float widthRect;
    private float lengthRect;
    private RasterContainer[,] raster;


 //   int x = e.getX();
 //   int y = e.getY();
 //   x = (x - UNBENUTZTEPIXELVONLINKS) / BREITERECHTECKE;
 //y = (y - UNBENUTZTEPIXELVONOBEN) / HÖHERECHTECKE;

    public LevelGrid(Terrain ter) {
        Vector3 tempVec = ter.transform.position;
        this.width = ter.terrainData.size.x;
        this.length = ter.terrainData.size.y;
        this.terX = tempVec.x;
        this.terY = tempVec.y;
        initRaster(calcRectsWidth(this.width), calcRectsLength(this.length));
    }

    private void initRaster(int rectsWidth, int rectsLength) {
        raster = new RasterContainer[rectsWidth, rectsLength];

        for (int i = 0; i < rectsWidth; i++)
        {
            for (int j = 0; j < rectsLength; j++)
            {
                raster[i,j] = initContainer(i, j);
            }
        }
    }

    private RasterContainer initContainer(int i, int j)
    {
        //TODO dividing the GameObjects in current szene in RasterContainers

        return null;
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

