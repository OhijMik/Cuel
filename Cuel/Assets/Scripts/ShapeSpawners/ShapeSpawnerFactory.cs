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
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float power = 5f;
            float powerMax = 10f;
            float powerMin = 1f;
            return new CubeSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        else if (shapeIndex == 1)       // Create ball spawner
        {
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float power = 5f;
            float powerMax = 25f;
            float powerMin = 1f;
            return new BallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        else if (shapeIndex == 2)       // Create triangle spawner
        {
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float power = 5f;
            float powerMax = 10f;
            float powerMin = 1f;
            return new TriangleSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        return null;
    }
}
