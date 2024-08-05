using UnityEngine;



public class Player : MonoBehaviour
{
    private bool _isMove = false;
    private KeyCode _currentKeyCode = KeyCode.None;
    private Vector2 _currentDirection = Vector2.zero;
    private Vector2 _frontDirection = Vector2.down;

    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerLight _playerLight;

    private float _stepIntervalTimer = 0f;
    public void Init()
    {
    }
    public void DeActive()
    {
        this.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        Move();
        Rotate();
        DoAnimation();
        SetSortingOrder();
    }

    private void SetSortingOrder()
    {
        //_bodyRenderer.sortingOrder = -(int)this.transform.position.y;
    }

    private void Move()
    {
        _stepIntervalTimer += Time.fixedDeltaTime;

        if (_isMove)
        {
            if (!Input.GetKey(_currentKeyCode))
            {
                _currentDirection = Vector2.zero;
                _isMove = false;
            }
            else
            {
                if (_stepIntervalTimer >= DataManager.Instance.stepSFXInterval)
                {
                    SoundManager.Instance.PlaySfx(SfxType.Step_1);
                    _stepIntervalTimer = 0f;
                }

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

        _rigidbody2D.MovePosition(_rigidbody2D.position + _currentDirection * DataManager.Instance.playerMoveSpeed * Time.fixedDeltaTime);
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

        if (_playerLight != null)
        {
            _playerLight.RePosition(_frontDirection);
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

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Monster"))
        {
            Instantiate(DataManager.Instance.gameEndUI).Init();
            DeActive();
        }
    }
}

