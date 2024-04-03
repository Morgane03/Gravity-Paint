using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
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
        }

        else if (direction.x < 0)
        {
            _animator.SetBool("Walk", true);
            _spriteRenderer.flipX = true;
        }

        else
        {
            _animator.SetBool("Walk", false);
        }
    }
}
