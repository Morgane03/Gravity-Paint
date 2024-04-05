using System.Collections;
using UnityEngine;

public class EnnemiAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private ParticleSystem _particles;

    private EnnemiPainted _ennemiPainted;
    private EnnemiMove _ennemiMove;

    public void Start()
    {
        _particles.Stop();
        _animator = GetComponent<Animator>();

        _ennemiPainted = GetComponent<EnnemiPainted>();
        _ennemiMove = GetComponent<EnnemiMove>();

        _ennemiMove.EnnemiWalkEvent += EnnemiWalkAnimation;
        _ennemiMove.CanAttackEvent += EnnemiAttackAnimation;
        _ennemiPainted.EnnemiPaintedEvent += EnnemiPaintedAnimation;
    }

    public void EnnemiPaintedAnimation()
    {
        _animator.SetBool("IsPainted", true);
        _animator.SetBool("Attack", false);
        _animator.SetBool("Walk", false);
        _particles.Play();

        StartCoroutine(WaitChangeAnimation());
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

    IEnumerator WaitChangeAnimation()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetBool("IsPainted", false);
    }
}
