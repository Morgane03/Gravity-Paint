using System;
using UnityEngine;

public class PlayerChangeGravity : MonoBehaviour
{
    public event Action PlayerChangeGravityUp;
    public event Action PlayerChangeGravityDown;

    [SerializeField]
    private int _playerGravitySpeed;

    private PlayerController _playerController;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private int _baseGravity;

    [SerializeField]
    private GameObject _baseCanvas;

    [SerializeField]
    private GameObject _reverseCanvas;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _baseCanvas.SetActive(true);
        _reverseCanvas.SetActive(false);
        _playerController.PlayerIsChangingGravityEvent += ChangeGravity;
    }

    public void ChangeGravity()
    {
        SoundManager.Instance.ChangeGravity();
        if (_rb.gravityScale >= 1)
        {
            PlayerChangeGravityUp?.Invoke();
            _rb.gravityScale *= -1 * _playerGravitySpeed * Time.deltaTime;
            _reverseCanvas.SetActive(true);
            _baseCanvas.SetActive(false);
            _spriteRenderer.flipY = true;
        }
        else
        {
            PlayerChangeGravityDown?.Invoke();
            _rb.gravityScale = _baseGravity;
            _baseCanvas.SetActive(true);
            _reverseCanvas.SetActive(false);
            _spriteRenderer.flipY = false;
        }
    }
}
