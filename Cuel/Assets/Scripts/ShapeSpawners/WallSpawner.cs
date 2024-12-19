using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class WallSpawner : ShapeSpawner
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int indexToSpawn = 2;

    private float wallSize = 0.5f;
    private float wallSizeMax = 10f;
    private float wallSizeIncrement = 0.05f;

    private float wallRange = 2f;
    private float wallRangeMax = 3f;
    private float wallRangeMin = 1f;
    private float wallRangeIncrement = 1f;


    public WallSpawner(Alteruna.Avatar avatar, Spawner spawner)
    {
        this.avatar = avatar;
        this.spawner = spawner;
    }

    public void UpdateSpawner(GameObject tempShape)
    {
        if (!avatar.IsMe)
        {
            return;
        }

        // Scale the wall size
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (wallSize < wallSizeMax)
            {
                wallSize += wallSizeIncrement;
            }
        }

        // Spawn wall
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnWall();
        }

        // Increase the wallRange
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)   // Forward
        {
            if (wallRange < wallRangeMax)
            {
                wallRange += wallRangeIncrement;
            }
        }

        // Decrease the wallRange
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)    // Backward
        {
            if (wallRange > wallRangeMin)
            {
                wallRange -= wallRangeIncrement;
            }
        }

        // Add the temp shape
        tempShape.transform.localScale = new Vector3(wallSize, wallSize, wallSize);
        tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * wallRange;
        tempShape.transform.rotation = Camera.main.transform.rotation;
        tempShape.transform.eulerAngles = new Vector3(tempShape.transform.eulerAngles.x, tempShape.transform.eulerAngles.y, tempShape.transform.eulerAngles.z);
    }

    private void SpawnWall()
    {
        // Spawn the wall at range or at a solid object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity))
        {
            if (hit.distance < wallRange)
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * hit.distance * 0.9f,
                            Camera.main.transform.rotation, new Vector3(wallSize, wallSize, wallSize));
            }
            else
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * wallRange,
                            Camera.main.transform.rotation, new Vector3(wallSize, wallSize, wallSize));
            }
        }
        else
        {
            spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * wallRange,
                            Camera.main.transform.rotation, new Vector3(wallSize, wallSize, wallSize));
        }
        wallSize = 0.5f;
    }

    public float GetSize()
    {
        return wallSize;
    }

    public float GetRange()
    {
        return wallRange;
    }
}
