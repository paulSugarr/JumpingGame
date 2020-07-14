using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private Color _defaultColor;
    private PlayerControls _playerControls;
    private void Start()
    {
        _playerControls = GetComponent<PlayerControls>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _defaultColor = _sprite.color;
    }
    private void Update()
    {
        if (_playerControls.AllowMove())
        {
            _sprite.color = _color;
        }
        else
        {
            _sprite.color = Color.Lerp(_sprite.color, _defaultColor, 0.1f);
        }
    }
}
