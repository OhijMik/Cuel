using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.position * 2 - Camera.main.transform.position;
        transform.position = Camera.main.transform.position;
    }
}
