using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Health -= _damage;
        }
    }
}
