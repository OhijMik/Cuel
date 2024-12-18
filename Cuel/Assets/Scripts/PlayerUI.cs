using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI rangeText;
    private CubeSpawner cubeSpawner;

    private void Start()
    {
        cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void Update()
    {
        sizeText.text = ((int)(cubeSpawner.GetSize() * 10)).ToString();
        rangeText.text = ((int)cubeSpawner.GetRange()).ToString() + "m";
    }
}
