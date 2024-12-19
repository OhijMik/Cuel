using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : ShapeSpawner
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int indexToSpawn = 0;

    private float cubeSize = 0.5f;
    private float cubeSizeMax = 10f;
    private float cubeSizeIncrement = 0.05f;

    private float cubeRange = 5f;
    private float cubeRangeMax = 10f;
    private float cubeRangeMin = 1f;
    private float cubeRangeIncrement = 1f;


    public CubeSpawner(Alteruna.Avatar avatar, Spawner spawner)
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

        // Scale the cube size
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cubeSize < cubeSizeMax)
            {
                cubeSize += cubeSizeIncrement;
            }
        }

        // Spawn Cube
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnCube();
        }

        // Increase the cubeRange
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)   // Forward
        {
            if (cubeRange < cubeRangeMax)
            {
                cubeRange += cubeRangeIncrement;
            }
        }

        // Decrease the cubeRange
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)    // Backward
        {
            if (cubeRange > cubeRangeMin)
            {
                cubeRange -= cubeRangeIncrement;
            }
        }

        // Add the temp shape
        tempShape.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * cubeRange;
        tempShape.transform.rotation = Camera.main.transform.rotation;
    }

    private void SpawnCube()
    {
        // Spawn the cube at range or at a solid object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity))
        {
            if (hit.distance < cubeRange)
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * hit.distance * 0.9f,
                            Camera.main.transform.rotation, new Vector3(cubeSize, cubeSize, cubeSize));
            }
            else
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * cubeRange,
                            Camera.main.transform.rotation, new Vector3(cubeSize, cubeSize, cubeSize));
            }
        }
        else
        {
            spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * cubeRange,
                            Camera.main.transform.rotation, new Vector3(cubeSize, cubeSize, cubeSize));
        }
        cubeSize = 0.5f;
    }

    public float GetSize()
    {
        return cubeSize;
    }

    public float GetRange()
    {
        return cubeRange;
    }
}
