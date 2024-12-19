using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : ShapeSpawner
{
    private Alteruna.Avatar avatar;
    private Spawner spawner;
    private int indexToSpawn = 1;

    private float ballSize = 0.5f;
    private float ballSizeMax = 10f;
    private float ballSizeIncrement = 0.05f;

    private float ballRange = 5f;
    private float ballRangeMax = 25f;
    private float ballRangeMin = 1f;
    private float ballRangeIncrement = 1f;


    public BallSpawner(Alteruna.Avatar avatar, Spawner spawner)
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

        // Scale the ball size
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (ballSize < ballSizeMax)
            {
                ballSize += ballSizeIncrement;
            }
        }

        // Spawn ball
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnBall();
        }

        // Increase the ballRange
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)   // Forward
        {
            if (ballRange < ballRangeMax)
            {
                ballRange += ballRangeIncrement;
            }
        }

        // Decrease the ballRange
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)    // Backward
        {
            if (ballRange > ballRangeMin)
            {
                ballRange -= ballRangeIncrement;
            }
        }
    }

    private void SpawnBall()
    {
        // Spawn the ball at range or at a solid object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
            Mathf.Infinity))
        {
            if (hit.distance < ballRange)
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * hit.distance * 0.9f,
                            Camera.main.transform.rotation, new Vector3(ballSize, ballSize, ballSize));
            }
            else
            {
                spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * ballRange,
                            Camera.main.transform.rotation, new Vector3(ballSize, ballSize, ballSize));
            }
        }
        else
        {
            spawner.Spawn(indexToSpawn, Camera.main.transform.position + Camera.main.transform.forward * ballRange,
                            Camera.main.transform.rotation, new Vector3(ballSize, ballSize, ballSize));
        }
        ballSize = 0.5f;
    }

    public float GetSize()
    {
        return ballSize;
    }

    public float GetRange()
    {
        return ballRange;
    }
}
