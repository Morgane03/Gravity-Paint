using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private ParticleSystem _particleSystem;

    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMove.PlayerWalkAnimationEvent += WalkAnimation;
    }

    public void WalkAnimation(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _animator.SetBool("Walk", true);
            _spriteRenderer.flipX = false;
            _particleSystem.transform.rotation = Quaternion.Euler(39.635f, -90, 90);
        }

        else if (direction.x < 0)
        {
            _animator.SetBool("Walk", true);
            _spriteRenderer.flipX = true;
            _particleSystem.transform.rotation = Quaternion.Euler(129.635f, -90, 90);
        }

        else
        {
            _animator.SetBool("Walk", false);
        }
    }
}
