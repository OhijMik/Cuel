using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI rangeText;
    private ShapeSpawner shapeSpawner;

    private void Update()
    {
        Alteruna.Avatar avatar = GetComponent<Alteruna.Avatar>();
        Player player = GetComponent<Player>();

        if (!avatar.IsMe)
        {
            return;
        }

        shapeSpawner = player.GetSpawner();
        if (shapeSpawner != null)
        {
            sizeText.text = ((int)(shapeSpawner.GetSize() * 10)).ToString();
            rangeText.text = ((int)shapeSpawner.GetPower()).ToString();
        }


    }
}
