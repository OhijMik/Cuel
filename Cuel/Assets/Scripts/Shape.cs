using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private float damage;
    private float health;
    private bool hit = false;
    private Player owner;

    public void SetOwner(Player owner)
    {
        this.owner = owner;

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && !hit && col.gameObject.GetComponent<Player>() != owner)
        {
            Player player = col.gameObject.GetComponent<Player>();
            player.Hit(damage);
            hit = true;
        }
        else if (tag == "Ball" && col.gameObject.tag == "Cube" && col.gameObject.GetComponent<Shape>().GetOwner() != owner)
        {
            Destroy(col.gameObject);
        }
        else if (tag == "Triangle" && col.gameObject.tag == "Ball" && col.gameObject.GetComponent<Shape>().GetOwner() != owner)
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag != "Player")
        {
            hit = true;
        }
    }

    public Player GetOwner()
    {
        return owner;
    }
}
