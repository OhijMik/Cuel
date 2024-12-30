using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Player player;
    [SerializeField] private float damage = 10f;

    private void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // float power = player.GetSpawner().GetPower();

        // rigidbody = GetComponent<Rigidbody>();
        // rigidbody.velocity = (transform.position - Camera.main.transform.position) * power;
        // transform.position = Camera.main.transform.position + Camera.main.transform.forward;

        // rigidbody.mass = transform.localScale.x * 2;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = col.gameObject.GetComponent<Player>();
            player.Hit(damage);
        }
    }
}
