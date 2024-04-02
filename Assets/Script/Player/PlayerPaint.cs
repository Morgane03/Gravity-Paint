using UnityEngine;

public class PlayerPaint : MonoBehaviour
{
    private Collider2D _collider2D;
    private PlayerController _playerController;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _playerController.PlayerIsPaintingEvent += Paint;
    }

    public void Paint()
    {
        
    }
}
