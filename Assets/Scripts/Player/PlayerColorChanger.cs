using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private Color _defaultColor;
    private float _jumpAllowHeight;
    private void Start()
    {
        _jumpAllowHeight = GetComponent<PlayerControls>().JumpAllowHeight;
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _defaultColor = _sprite.color;
    }
    private void FixedUpdate()
    {
        if (transform.position.y <= _jumpAllowHeight && _rigidbody.velocity.y <= 0f)
        {
            _sprite.color = _color;
        }
        else
        {
            _sprite.color = Color.Lerp(_sprite.color, _defaultColor, 0.1f);
        }
    }
}
