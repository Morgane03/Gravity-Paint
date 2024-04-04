using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rb;

    [SerializeField] private Vector2 _jumpForce;
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
        _playerController.PlayerIsJumpingEvent += Jump;
    }

    public void Jump()
    {
        _rb.AddForce(_jumpForce);
    }
}
