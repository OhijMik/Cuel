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

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

    private void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnCube();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DespawnCube();
        }
    }

    private void SpawnCube()
    {
        spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * 1.5f,
                      Camera.main.transform.rotation, new Vector3(0.5f, 0.5f, 0.5f));
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
