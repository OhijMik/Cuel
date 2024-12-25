using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class TriangleSpawner : ShapeSpawner
{
    public TriangleSpawner(Alteruna.Avatar avatar, Spawner spawner, int indexToSpawn, float size, float sizeMax, float sizeIncrement,
                        float power, float powerMax, float powerMin)
                        : base(avatar, spawner, indexToSpawn, size, sizeMax, sizeIncrement, power, powerMax, powerMin)
    {

    }
}
