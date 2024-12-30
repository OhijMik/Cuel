using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Player player;
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("dgasui");
        if (col.gameObject.tag == "Player")
        {
            Player player = col.gameObject.GetComponent<Player>();
            player.Hit(damage);
        }
    }
}
