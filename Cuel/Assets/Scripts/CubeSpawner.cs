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
    // private GameObject tempCube;
    [SerializeField] private Transform tempCubeInstantiate;
    private Transform tempCube;

    private float cubeSize = 0.5f;
    private float cubeRange = 5f;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        //tempCube = GameObject.FindGameObjectWithTag("TempCube");
        tempCube = Instantiate(tempCubeInstantiate, Camera.main.transform.position + Camera.main.transform.forward * cubeRange, Camera.main.transform.rotation);
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DespawnCube();
        }

        tempCube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        tempCube.transform.position = Camera.main.transform.position + Camera.main.transform.forward * cubeRange;
        tempCube.transform.rotation = Camera.main.transform.rotation;
    }

    private void SpawnCube()
    {
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * cubeRange,
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
        return cubeRange;
    }
}
