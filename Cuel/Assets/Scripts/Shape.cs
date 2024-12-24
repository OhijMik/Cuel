using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMassUpdate : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = (transform.position - Camera.main.transform.position) * 2;
        transform.position = Camera.main.transform.position;
    }

    private void Update()
    {
        rigidbody.mass = transform.localScale.x;
    }
}
