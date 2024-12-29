using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSpawner : MonoBehaviour
{
    Spawner spawner;
    Multiplayer multiplayer;
    private void Start()
    {
        spawner = GetComponent<Spawner>();
        multiplayer = GetComponent<Multiplayer>();

        UnityEvent<User, GameObject> OnShapeSpawnEvent = new UnityEvent<User, GameObject>();
        OnShapeSpawnEvent.AddListener(SetShape);
        spawner.OnObjectSpawn = OnShapeSpawnEvent;
    }

    private void SetShape(User user, GameObject shape)
    {
        Debug.Log(multiplayer.GetAvatar(user.Name).GetComponent<Player>(), shape);

        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // float power = player.GetSpawner().GetPower();

        // rigidbody = GetComponent<Rigidbody>();
        // rigidbody.velocity = (transform.position - Camera.main.transform.position) * power;
        // transform.position = Camera.main.transform.position + Camera.main.transform.forward;

        // rigidbody.mass = transform.localScale.x * 2;
    }
}
