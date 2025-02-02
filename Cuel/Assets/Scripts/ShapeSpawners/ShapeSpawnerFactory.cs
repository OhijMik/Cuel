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
            float sizeMax = 5f;
            float sizeIncrement = 0.05f;

            float power = 2f;
            float powerMax = 3f;
            float powerMin = 1f;
            return new CubeSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        else if (shapeIndex == 1)       // Create ball spawner
        {
            float size = 0.5f;
            float sizeMax = 6f;
            float sizeIncrement = 0.05f;

            float power = 4f;
            float powerMax = 6f;
            float powerMin = 3f;
            return new BallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        else if (shapeIndex == 2)       // Create triangle spawner
        {
            float size = 0.5f;
            float sizeMax = 3;
            float sizeIncrement = 0.05f;

            float power = 10f;
            float powerMax = 15f;
            float powerMin = 8f;
            return new TriangleSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, power,
                                    powerMax, powerMin);
        }
        return null;
    }
}
