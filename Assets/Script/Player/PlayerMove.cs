using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Déplace le joueur quand l'event est lancer via les inputs
    /// </summary>
    [SerializeField]
    private int _playerSpeed;

    private PlayerController _playerController;
    private Rigidbody2D _rb;

    public bool _canMove;

    public event Action<Vector2> PlayerWalkAnimationEvent;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _playerController.PlayerIsMovingEvent += MovePlayer;
    }

    public void MovePlayer()
    {
        if (_canMove)
        {
            _rb.velocity = _playerController.DirectionPlayer * _playerSpeed;
            PlayerWalkAnimationEvent?.Invoke(_playerController.DirectionPlayer);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _canMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _canMove = false;
        }
    }   
}
