using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private bool hit = false;
    private Player player;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && !hit && col.gameObject.GetComponent<Player>() != player)
        {
            Debug.Log("hit");
            Player player = col.gameObject.GetComponent<Player>();
            player.Hit(damage);
            hit = true;
        }

        if (col.gameObject.tag == "Ground")
        {
            hit = true;
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
