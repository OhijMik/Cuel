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
        Player player = multiplayer.GetAvatar(user.Name).GetComponent<Player>();

        if (player.GetSpawner() == null)
        {
            return;
        }
        float power = player.GetSpawner().GetPower();

        Rigidbody rigidbody = shape.GetComponent<Rigidbody>();
        rigidbody.velocity = (shape.transform.position - Camera.main.transform.position) * power;
        shape.transform.position = Camera.main.transform.position + Camera.main.transform.forward * shape.transform.localScale.x;

        rigidbody.mass = shape.transform.localScale.x;

        shape.GetComponent<Shape>().SetOwner(player);
    }
}
