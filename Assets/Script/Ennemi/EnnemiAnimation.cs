using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EnnemiAnimation : MonoBehaviour
{
    private EnnemiPainted _ennemiPainted;
    private EnnemiMove _ennemiMove;
    private Animator _animator;

    [SerializeField] private ParticleSystem _particles;


    public void Start()
    {
        _particles.Stop();
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
        _particles.Play();
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
