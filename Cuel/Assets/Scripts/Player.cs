using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int currShape = -1;  // 0: cube, 1: ball, 2: triangle
    private ShapeSpawner currShapeSpawner;

    [SerializeField] private GameObject tempCubeInstantiate;
    [SerializeField] private GameObject tempBallInstantiate;
    [SerializeField] private GameObject tempTriangleInstantiate;
    private GameObject tempShape;

    private float health = 100f;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        if (!avatar.IsMe)
        {
            return;
        }

        currShape = 0;
        tempShape = Instantiate(tempCubeInstantiate, Camera.main.transform.position, Camera.main.transform.rotation);
        currShapeSpawner = ShapeSpawnerFactory.createShapeSpawner(currShape, avatar, spawner);
        Debug.Log(avatar.IsMe + "0");
    }

    private void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        if (health <= 0)
        {
            Debug.Log("Dead");
        }

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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(tempShape);
            currShape = 2;
            tempShape = Instantiate(tempTriangleInstantiate, Camera.main.transform.position, Camera.main.transform.rotation);
            currShapeSpawner = ShapeSpawnerFactory.createShapeSpawner(currShape, avatar, spawner);
        }

        if (currShape != -1)
        {
            // Update the current spawner
            currShapeSpawner.UpdateSpawner(tempShape);
        }

        float size = 0.25f + (float)(health / 100 * 0.75);
        transform.localScale = new Vector3(size, size, size);
    }

    public ShapeSpawner GetSpawner()
    {
        if (!avatar.IsMe)
        {
            return null;
        }
        return currShapeSpawner;
    }

    public Alteruna.Avatar GetAvatar()
    {
        if (!avatar.IsMe)
        {
            return null;
        }
        return avatar;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Hit(float damage)
    {
        health -= damage;
    }
}
