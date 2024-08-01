using UnityEngine;

public enum MoveDirection
{
    None = 0,
    Up = 1,
    Down = -1,
    Side = 2,
}

public class Player : MonoBehaviour
{
    private bool _isMove = false;
    private KeyCode _currentKeyCode = KeyCode.None;
    private Vector2 _currentDirection = Vector2.zero;
    private Vector2 _frontDirection = Vector2.zero;

    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private Animator _animator;

    public void Init()
    {
    }

    public void Update()
    {
        Move();
        Rotate();
        DoAnimation();
    }

    private void Move()
    {
        if (_isMove)
        {
            if (!Input.GetKey(_currentKeyCode))
            {
                _currentDirection = Vector2.zero;
                _isMove = false;
            }
        }

        if (!_isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SetDirection(Vector2.up, KeyCode.W);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                SetDirection(Vector2.down, KeyCode.S);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SetDirection(Vector2.left, KeyCode.A);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetDirection(Vector2.right, KeyCode.D);
            }
        }

        transform.Translate(_currentDirection * DataManager.Instance.moveSpeed * Time.deltaTime);
    }
    private void SetDirection(Vector2 _direction, KeyCode _keyCode)
    {
        _currentDirection = _direction;
        _currentKeyCode = _keyCode;
        _isMove = true;
    }

    private void Rotate()
    {
        if (_isMove)
        {
            if (_currentKeyCode == KeyCode.W)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    _frontDirection = Vector2.down;
                }
                else
                {
                    _frontDirection = Vector2.up;
                }

            }
            else if (_currentKeyCode == KeyCode.S)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _frontDirection = Vector2.up;
                }
                else
                {
                    _frontDirection = Vector2.down;
                }
            }
            else if (_currentKeyCode == KeyCode.A)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    _bodyRenderer.flipX = true;
                    _frontDirection = Vector2.right;
                }
                else
                {
                    _bodyRenderer.flipX = false;
                    _frontDirection = Vector2.left;
                }
            }
            else if (_currentKeyCode == KeyCode.D)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    _bodyRenderer.flipX = false;
                    _frontDirection = Vector2.left;
                }
                else
                {
                    _bodyRenderer.flipX = true;
                    _frontDirection = Vector2.right;
                }
            }
        }
        else
        {
            _frontDirection = _currentDirection;
        }
    }
    private void DoAnimation()
    {
        MoveDirection _moveDirection = MoveDirection.None;

        if (_isMove)
        {
            if (_frontDirection == Vector2.left || _frontDirection == Vector2.right)
            {
                _moveDirection = MoveDirection.Side;
            }
            else if (_frontDirection == Vector2.up)
            {
                _moveDirection = MoveDirection.Up;
            }
            else if (_frontDirection == Vector2.down)
            {
                _moveDirection = MoveDirection.Down;
            }
        }


        _animator.SetInteger("MoveDirection", (int)_moveDirection);
    }
}

