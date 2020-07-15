using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScoreObject : MonoBehaviour
{
    [SerializeField] private int _scoreAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            GameManager.AddScore(_scoreAmount);
            Destroy(gameObject);
        }

    }
}
