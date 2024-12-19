using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI rangeText;
    private ShapeSpawner shapeSpawner;

    private void Start()
    {
        shapeSpawner = GetComponent<Player>().GetSpawner();
    }

    private void Update()
    {
        sizeText.text = ((int)(shapeSpawner.GetSize() * 10)).ToString();
        rangeText.text = ((int)shapeSpawner.GetRange()).ToString() + "m";
    }
}
