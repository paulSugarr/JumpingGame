using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : InteractingObject
{
    [SerializeField] private int _healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Health += _healAmount;
            Destroy();
        }
    }
}
