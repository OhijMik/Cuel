using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private new Rigidbody rigidbody;
    [SerializeField] private float health = 10;

    private void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        float power = player.GetSpawner().GetPower();

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = (transform.position - Camera.main.transform.position) * power;
        transform.position = Camera.main.transform.position + Camera.main.transform.forward;
    }

    private void Update()
    {
        rigidbody.mass = transform.localScale.x;
    }
}
