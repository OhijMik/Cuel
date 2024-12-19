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
    private Transform tempCube;

    private float cubeSize = 0.5f;
    private float cubeRange = 5f;

    public CubeSpawner(Alteruna.Avatar avatar, Spawner spawner)
    {
        this.avatar = avatar;
        this.spawner = spawner;
    }

    public void UpdateSpawner()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        // Scale the cube size
        if (Input.GetKey(KeyCode.F))
        {
            if (cubeSize < 10f)
            {
                cubeSize += 0.05f;
            }
        }

        // Spawn Cube
        if (Input.GetKeyUp(KeyCode.F))
        {
            SpawnCube();
        }

        // Increase the cubeRange
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cubeRange < 10f)
            {
                cubeRange += 0.1f;
            }
        }

        // Decrease the cubeRange
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (cubeRange > 2f)
            {
                cubeRange -= 0.3f;
            }
        }
    }

    private void SpawnCube()
    {
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * cubeRange,
                      Camera.main.transform.rotation, new Vector3(cubeSize, cubeSize, cubeSize));
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
