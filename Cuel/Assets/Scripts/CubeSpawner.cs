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
    private float cubeScale = 0.5f;
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
            if (cubeScale < 10f)
            {
                cubeScale += 0.05f;
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
            if (range < 30f)
            {
                range += 0.4f;
            }
        }

        // Decrease the range
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (range > 5f)
            {
                range -= 0.4f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DespawnCube();
        }

        Debug.Log(Camera.main.transform.position);

        tempCube.transform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        tempCube.transform.position = Camera.main.transform.position + Camera.main.transform.forward * range;
        tempCube.transform.rotation = Camera.main.transform.rotation;
    }

    private void SpawnCube()
    {
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * range,
                      Camera.main.transform.rotation, new Vector3(cubeScale, cubeScale, cubeScale));
        cubeScale = 0.5f;
    }

    private void DespawnCube()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity, despawnLayer))
        {
            spawner.Despawn(hit.transform.gameObject);
        }
    }
}
