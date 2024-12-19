using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int currShape;  // 0: cube, 1: sphere, 2: triangle
    private ShapeSpawner currShapeSpawner;

    [SerializeField] private GameObject tempCubeInstantiate;
    [SerializeField] private GameObject tempBallInstantiate;
    private GameObject tempShape;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        currShape = 0;
        tempShape = Instantiate(tempCubeInstantiate, Camera.main.transform.position, Camera.main.transform.rotation);
        currShapeSpawner = ShapeSpawnerFactory.createShapeSpawner(currShape, avatar, spawner);
    }

    private void Update()
    {
        // Change the current shape spawner
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(tempShape);
            currShape = 0;
            tempShape = Instantiate(tempCubeInstantiate, Camera.main.transform.position, Camera.main.transform.rotation);
            currShapeSpawner = ShapeSpawnerFactory.createShapeSpawner(currShape, avatar, spawner);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(tempShape);
            currShape = 1;
            tempShape = Instantiate(tempBallInstantiate, Camera.main.transform.position, Camera.main.transform.rotation);
            currShapeSpawner = ShapeSpawnerFactory.createShapeSpawner(currShape, avatar, spawner);
        }

        currShapeSpawner.UpdateSpawner();

        // Add the temp shape
        tempShape.transform.localScale = new Vector3(currShapeSpawner.GetSize(), currShapeSpawner.GetSize(), currShapeSpawner.GetSize());
        tempShape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * currShapeSpawner.GetRange();
        tempShape.transform.rotation = Camera.main.transform.rotation;
    }

    public ShapeSpawner GetSpawner()
    {
        return currShapeSpawner;
    }
}
