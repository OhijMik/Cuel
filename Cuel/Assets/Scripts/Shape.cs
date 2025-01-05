using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private bool hit = false;
    private Player owner;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "owner" && !hit && col.gameObject.GetComponent<Shape>().GetOwner() != owner)
        {
            Player owner = col.gameObject.GetComponent<Player>();
            owner.Hit(damage);
            hit = true;
        }
        else if (tag == "Ball" && col.gameObject.tag == "Cube" && col.gameObject.GetComponent<Shape>().GetOwner() != owner)
        {
            Destroy(col.gameObject);
        }
        else if (tag == "Triangle" && col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag != "Player")
        {
            hit = true;
        }
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }

    public Player GetOwner()
    {
        return owner;
    }
}
