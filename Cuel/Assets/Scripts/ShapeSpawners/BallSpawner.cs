using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : ShapeSpawner
{
    public BallSpawner(Alteruna.Avatar avatar, Spawner spawner, int indexToSpawn, float size, float sizeMax, float sizeIncrement,
                        float power, float powerMax, float powerMin)
                        : base(avatar, spawner, indexToSpawn, size, sizeMax, sizeIncrement, power, powerMax, powerMin)
    {

    }
}
