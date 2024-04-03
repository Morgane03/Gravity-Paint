using System.Collections;
using UnityEngine;

public class EnnemiAnimation : MonoBehaviour
{
    private EnnemiPainted _ennemiPainted;
    private EnnemiMove _ennemiMove;
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _ennemiPainted = GetComponent<EnnemiPainted>();
        _ennemiMove = GetComponent<EnnemiMove>();

        _ennemiPainted.EnnemiPaintedEvent += EnnemiPaintedAnimation;
        _ennemiMove.EnnemiWalkEvent += EnnemiWalkAnimation;
        _ennemiMove.CanAttackEvent += EnnemiAttackAnimation;
    }

    public void EnnemiPaintedAnimation()
    {
        _animator.SetBool("IsPainted", true);
        _animator.SetBool("Attack", false);
        _animator.SetBool("Walk", false);
    }

    public void EnnemiAttackAnimation()
    {
        _animator.SetBool("Attack", true);
        _animator.SetBool("Walk", false);
    }

    public void EnnemiWalkAnimation()
    {
        _animator.SetBool("Attack", false);
        _animator.SetBool("Walk", true);
    }
}
