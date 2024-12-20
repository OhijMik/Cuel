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

            float range = 5f;
            float rangeMax = 10f;
            float rangeMin = 1f;
            return new WallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, range,
                                    rangeMax, rangeMin);
        }
        else if (shapeIndex == 1)       // Create ball spawner
        {
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float range = 5f;
            float rangeMax = 25f;
            float rangeMin = 1f;
            return new WallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, range,
                                    rangeMax, rangeMin);
        }
        else if (shapeIndex == 2)       // Create wall spawner
        {
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float range = 2f;
            float rangeMax = 3f;
            float rangeMin = 1f;
            return new WallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, range,
                                    rangeMax, rangeMin);
        }
        else if (shapeIndex == 3)       // Create triangle spawner
        {
            float size = 0.5f;
            float sizeMax = 10f;
            float sizeIncrement = 0.05f;

            float range = 5f;
            float rangeMax = 10f;
            float rangeMin = 1f;
            return new WallSpawner(avatar, spawner, shapeIndex, size, sizeMax, sizeIncrement, range,
                                    rangeMax, rangeMin);
        }
        return null;
    }
}
