using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float JumpAllowHeight = -0.5f;
    [SerializeField] private ControlType _controlType;
    [SerializeField] private float _jumpForce;
    [Tooltip("Используется только при типе управления Cooldown"), SerializeField] private float _cooldownJump = 1.5f;


    private Rigidbody2D _rigidbody;
    private float _controlTypeMultiplier = 2f;
    private float _timer = 0;
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main;
        _timer = _cooldownJump;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        switch (_controlType)
        {
            case ControlType.Continuous:
                ContinousMove();
                break;
            case ControlType.Discrete:
                DiscreteMove();
                break;
            case ControlType.Cooldown:
                CooldownMove();
                break;
            default:
                throw new System.Exception("Error in control settings. Type is unknown");
        }

    }
    private void DiscreteMove()
    {
        if (Input.GetMouseButton(0) && transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f)
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            Vector2 direction;
            if (mousePosition.x >= transform.position.x + 1.5f) 
            { 
                direction = (2 * Vector2.up + Vector2.right).normalized;
            }
            else if (mousePosition.x <= transform.position.x - 1.5f) 
            { 
                direction = (2 * Vector2.up + Vector2.left).normalized;
            }
            else 
            { 
                direction = Vector2.up; 
            }
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(direction * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void ContinousMove()
    {
        if (Input.GetMouseButton(0) && transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f)
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            Vector2 position = transform.position;
            position.y = 0;
            Vector2 direction = (mousePosition - position).normalized;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction * _jumpForce * _controlTypeMultiplier, ForceMode2D.Impulse);
        }
    }
    private void CooldownMove()
    {
        if (Input.GetMouseButton(0) && _timer >= _cooldownJump && _rigidbody.velocity.y <= 0f)
        {
            _timer = 0f;
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            Vector2 position = transform.position;
            Vector2 direction = (mousePosition - position).normalized;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction * _jumpForce * _controlTypeMultiplier, ForceMode2D.Impulse);
            Debug.Log((direction * _jumpForce * _controlTypeMultiplier).magnitude);
        }
    }

    private void ProjectionMove()
    {
        throw new System.NotImplementedException();
    }

    public bool AllowMove()
    {
        switch (_controlType)
        {
            case ControlType.Continuous:
                return transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f;
            case ControlType.Discrete:
                return transform.position.y <= JumpAllowHeight && _rigidbody.velocity.y <= 0f;
            case ControlType.Cooldown:
                return _timer >= _cooldownJump && _rigidbody.velocity.y <= 0f;
            default:
                throw new System.Exception("Error in control settings. Type is unknown");
        }
    }

}
public enum ControlType
{
    Discrete, Continuous, Cooldown
}
