using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class WallSpawner : ShapeSpawner
{

    public WallSpawner(Alteruna.Avatar avatar, Spawner spawner, int indexToSpawn, float size, float sizeMax, float sizeIncrement,
                        float range, float rangeMax, float rangeMin)
                        : base(avatar, spawner, indexToSpawn, size, sizeMax, sizeIncrement, range, rangeMax, rangeMin)
    {

    }
}
