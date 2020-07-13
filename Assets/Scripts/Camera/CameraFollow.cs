using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [Range(1f, 40f), SerializeField] private float _smooth;
    private Vector3 _offset;
    [SerializeField] private float _heightFollow;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }
    private void FixedUpdate()
    {
        Vector3 position = _offset;
        position.x = _target.position.x;
        if (_target.position.y >= _heightFollow)
        {
            position.y = Mathf.Lerp(transform.position.y, _target.position.y, 1 / _smooth);
        }
        else
        {
            position.y = Mathf.Lerp(transform.position.y, _heightFollow, 1 / _smooth);
        }
        transform.position = position;
    }

}