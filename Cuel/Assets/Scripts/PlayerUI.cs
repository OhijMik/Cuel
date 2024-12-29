using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI rangeText;
    [SerializeField] private TextMeshPro healthText;
    private ShapeSpawner shapeSpawner;

    private void Update()
    {
        Player player = GetComponent<Player>();
        if (player.GetAvatar() == null || !player.GetAvatar().IsMe)
        {
            return;
        }
        shapeSpawner = player.GetSpawner();
        if (shapeSpawner != null)
        {
            sizeText.text = ((int)(shapeSpawner.GetSize() * 10)).ToString();
            rangeText.text = ((int)shapeSpawner.GetPower()).ToString();
        }

        healthText.text = ((int)player.GetHealth()).ToString();
    }
}
