using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject sizeBar;
    [SerializeField] private Scrollbar scrollbar;
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
            // scrollbar.size = (int)(shapeSpawner.GetSize() / shapeSpawner.GetSizeMax() * 300) - 10;
            scrollbar.value = shapeSpawner.GetSize() / shapeSpawner.GetSizeMax();
            //Debug.Log(scrollbar.size);
            rangeText.text = ((int)shapeSpawner.GetPower()).ToString();
        }
    }
}
