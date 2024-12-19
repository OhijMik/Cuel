using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class ShapeSpawnerFactory
{
    public static ShapeSpawner createShapeSpawner(int shapeIndex, Alteruna.Avatar avatar, Spawner spawner)
    {
        if (shapeIndex == 0)
        {
            return new CubeSpawner(avatar, spawner);
        }
        else if (shapeIndex == 1)
        {
            return new BallSpawner(avatar, spawner);
        }
        return null;
    }
}
