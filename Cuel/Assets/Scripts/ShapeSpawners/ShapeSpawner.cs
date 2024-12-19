using System.Collections;
using System.Collections.Generic;
using Alteruna;
using Unity.VisualScripting;
using UnityEngine;

public interface ShapeSpawner
{
    public void UpdateSpawner();
    public float GetSize();
    public float GetRange();
}
