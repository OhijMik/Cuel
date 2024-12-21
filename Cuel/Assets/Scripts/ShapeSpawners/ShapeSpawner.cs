using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class ShapeSpawner
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int indexToSpawn;

    private float defaultSize;
    private float size;
    private float sizeMax;
    private float sizeIncrement = 0.05f;

    private float range;
    private float rangeMax;
    private float rangeMin;
    private float rangeIncrement = 1f;

    public ShapeSpawner(Alteruna.Avatar avatar, Spawner spawner, int indexToSpawn, float size, float sizeMax, float sizeIncrement,
                        float range, float rangeMax, float rangeMin)
    {
        this.avatar = avatar;
        this.spawner = spawner;
        this.indexToSpawn = indexToSpawn;
        this.size = size;
        this.defaultSize = size;
        this.sizeMax = sizeMax;
        this.sizeIncrement = sizeIncrement;
        this.range = range;
        this.rangeMax = rangeMax;
        this.rangeMin = rangeMin;
    }

    public void UpdateSpawner(GameObject tempShape)
    {
        if (!avatar.IsMe)
        {
            return;
        }

        // Scale the shape size
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (size < sizeMax)
            {
                size += sizeIncrement;
            }
        }

        // Spawn shape
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnShape();
        }

        // Increase the range
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)   // Forward
        {
            if (range < rangeMax)
            {
                range += rangeIncrement;
            }
        }

        // Decrease the range
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)    // Backward
        {
            if (range > rangeMin)
            {
                range -= rangeIncrement;
            }
        }

        UpdateTempShape(tempShape);
    }

    private void UpdateTempShape(GameObject tempShape)
    {
        if (!avatar.IsMe)
        {
            return;
        }

        // Spawn the temp shape at range or at a solid object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity))
        {
            if (hit.distance < range)
            {
                // Add the temp shape at the hit distance
                tempShape.transform.localScale = new Vector3(size, size, size);
                tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * hit.distance * 0.9f;
                tempShape.transform.rotation = Camera.main.transform.rotation;
                return;
            }
        }
        // Add the temp shape
        tempShape.transform.localScale = new Vector3(size, size, size);
        tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * range;
        tempShape.transform.rotation = Camera.main.transform.rotation;
    }

    private void SpawnShape()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        // Spawn the shape at range or at a solid object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity))
        {
            if (hit.distance < range)
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * hit.distance * 0.9f,
                            Camera.main.transform.rotation, new Vector3(size, size, size));
                size = defaultSize;
                return;
            }
        }
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * range,
                        Camera.main.transform.rotation, new Vector3(size, size, size));

        size = defaultSize;
    }

    public float GetSize()
    {
        return size;
    }
    public float GetRange()
    {
        return range;
    }
}
