using System;
using UnityEngine;

public class PlayerChangeGravity : MonoBehaviour
{
    public event Action PlayerChangeGravityUp;

    [SerializeField]
    private int _playerGravitySpeed;

    private PlayerController _playerController;
    private Rigidbody2D _rb;

    [SerializeField]
    private int _baseGravity;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _playerController.PlayerIsChangingGravityEvent += ChangeGravity;
    }

    public void ChangeGravity()
    {
        if (_rb.gravityScale >= 1)
        {
            PlayerChangeGravityUp?.Invoke();
            _rb.gravityScale *= -1 * _playerGravitySpeed * Time.deltaTime;
        }
        else
        {
            _rb.gravityScale = _baseGravity;
        }
    }
}
