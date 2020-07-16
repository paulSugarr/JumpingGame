using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    public bool Current;
    [Range(0f, 1f), SerializeField] private float _probability;
    [SerializeField] private GameObject _prefabObstacle;
    [SerializeField] private Vector2Int _fieldSize;

    public void RecalculateObjects()
    {

    }
}
