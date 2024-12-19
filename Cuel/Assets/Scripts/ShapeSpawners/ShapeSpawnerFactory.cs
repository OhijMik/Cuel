using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class ShapeSpawnerFactory
{
    public static ShapeSpawner createShapeSpawner(int shapeIndex, Alteruna.Avatar avatar, Spawner spawner)
    {
        if (shapeIndex == 0)            // Create cube spawner
        {
            float cubeSize = 0.5f;
            float cubeSizeMax = 10f;
            float cubeSizeIncrement = 0.05f;

            float cubeRange = 5f;
            float cubeRangeMax = 10f;
            float cubeRangeMin = 1f;
            return new CubeSpawner(avatar, spawner, shapeIndex, cubeSize, cubeSizeMax, cubeSizeIncrement, cubeRange,
                                    cubeRangeMax, cubeRangeMin);
        }
        else if (shapeIndex == 1)       // Create ball spawner
        {
            float ballSize = 0.5f;
            float ballSizeMax = 10f;
            float ballSizeIncrement = 0.05f;

            float ballRange = 5f;
            float ballRangeMax = 25f;
            float ballRangeMin = 1f;
            return new BallSpawner(avatar, spawner, shapeIndex, ballSize, ballSizeMax, ballSizeIncrement, ballRange,
                                    ballRangeMax, ballRangeMin);
        }
        else if (shapeIndex == 2)       // Create wall spawner
        {
            float wallSize = 0.5f;
            float wallSizeMax = 10f;
            float wallSizeIncrement = 0.05f;

            float wallRange = 2f;
            float wallRangeMax = 3f;
            float wallRangeMin = 1f;
            return new WallSpawner(avatar, spawner, shapeIndex, wallSize, wallSizeMax, wallSizeIncrement, wallRange,
                                    wallRangeMax, wallRangeMin);
        }
        return null;
    }
}
