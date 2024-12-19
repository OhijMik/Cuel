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

    private void UpdateTempShape(GameObject tempShape)
    {
        // Add the temp shape
        tempShape.transform.localScale = new Vector3(GetSize(), GetSize(), GetSize());
        tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * GetRange();
        tempShape.transform.rotation = Camera.main.transform.rotation;
        tempShape.transform.eulerAngles = new Vector3(tempShape.transform.eulerAngles.x, tempShape.transform.eulerAngles.y, tempShape.transform.eulerAngles.z);
    }

}
