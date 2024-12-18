using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallPhysicsMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private RigidbodySynchronizable rigid;
    private Alteruna.Avatar avatar;

    private void Awake()
    {
        rigid = GetComponent<RigidbodySynchronizable>();
        avatar = GetComponent<Alteruna.Avatar>();
    }

    private void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        rigid.AddForce(movementVector * moveSpeed);
    }
}
