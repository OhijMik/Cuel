using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMassUpdate : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.mass = transform.localScale.x;
    }
}
