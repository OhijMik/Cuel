using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealthText : MonoBehaviour
{
    [SerializeField] private TextMeshPro healthText;
    private PlayerShoot playerShoot;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        healthText.text = playerShoot.health.ToString();
    }

}
