using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;

    [SerializeField] private int indexToSpawn = 0;
    [SerializeField] private LayerMask despawnLayer;
    private GameObject tempCube;
    private float cubeSize = 0.5f;
    private float range = 5f;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        tempCube = GameObject.FindGameObjectWithTag("TempCube");
    }

    private void Update()
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

        // Increase the range
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (range < 10f)
            {
                range += 0.3f;
            }
        }

        // Decrease the range
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (range > 2f)
            {
                range -= 0.3f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DespawnCube();
        }
    }

    private void SpawnCube()
    {
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * range,
                      Camera.main.transform.rotation, new Vector3(cubeSize, cubeSize, cubeSize));
        cubeSize = 0.5f;
    }

    private void DespawnCube()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity, despawnLayer))
        {
            spawner.Despawn(hit.transform.gameObject);
        }
    }

    public float GetSize()
    {
        return cubeSize;
    }

    public float GetRange()
    {
        return range;
    }
}
