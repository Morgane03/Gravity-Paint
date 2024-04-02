using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Déplace le joueur quand l'event est lancer via les inputs
    /// </summary>
    [SerializeField]
    private int _playerSpeed;

    private PlayerController _playerController;

    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
        _playerController.PlayerIsMovingEvent += MovePlayer;
    }

    public void MovePlayer()
    {
        _rb.velocity = _playerController.DirectionPlayer * _playerSpeed;
    }
}
