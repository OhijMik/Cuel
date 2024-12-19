using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public interface ShapeSpawner
{
    public void UpdateSpawner(GameObject tempShape);
    public float GetSize();
    public float GetRange();
}
