using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float JumpAllowHeight = -0.5f;
    [SerializeField] private ControlType _controlType;
    [SerializeField] private float _jumpForce;


    private Rigidbody2D _rigidbody;
    private float _controlTypeMultiplier = 2f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        switch (_controlType)
        {
            case ControlType.Continuous:
                ContinousMove();
                break;
            case ControlType.Discrete:
                DiscreteMove();
                break;
            default:
                throw new System.Exception("Error in control settings. Type is unknown");
        }

    }
    private void DiscreteMove()
    {
        if (Input.GetMouseButton(0) && transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f)
        {
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction;
            if (mousePosition.x >= transform.position.x + 1.5f) 
            { 
                direction = (2 * Vector3.up + Vector3.right).normalized;
            }
            else if (mousePosition.x <= transform.position.x - 1.5f) 
            { 
                direction = (2 * Vector3.up + Vector3.left).normalized;
            }
            else 
            { 
                direction = Vector3.up; 
            }
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void ContinousMove()
    {
        if (Input.GetMouseButton(0) && transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f)
        {
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            var position = transform.position;
            position.y = 0;
            var direction = (mousePosition - position).normalized;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction * _jumpForce * _controlTypeMultiplier, ForceMode2D.Impulse);
        }
    }
    
}
public enum ControlType
{
    Discrete, Continuous
}
