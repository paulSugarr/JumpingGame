using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    public bool Current;
    [SerializeField] private List<GameObject> _obstaclePrefabs;
    [SerializeField] private float _minHeightOffset;
    [SerializeField] private Vector2 _dispersionOffset;
    [SerializeField] private float _spawnCooldown = 1f;
    private float _timer = 1f;
    private GameObject _player;
    private void Start()
    {
        _player = GameManager.Player;
    }
    private void Update()
    {
        if (Current && _timer >= _spawnCooldown)
        {
            _timer = 0f;
            if (_obstaclePrefabs == null || _obstaclePrefabs.Count <= 0) { return; }
            var rand = Random.Range(0, _obstaclePrefabs.Count);
            var randDisplaceY = Random.Range(-_dispersionOffset.y, _dispersionOffset.y);
            var randDisplaceX = Random.Range(-_dispersionOffset.x, _dispersionOffset.x);
            var position = _player.transform.position + new Vector3(randDisplaceX, _minHeightOffset + randDisplaceY, 0);
            var obstacle = Instantiate(_obstaclePrefabs[rand], position, Quaternion.identity);
            obstacle.transform.parent = transform;
        }
        _timer += Time.deltaTime;
    }
}
