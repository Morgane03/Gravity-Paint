using UnityEngine;

public class EnnemiAnimation : MonoBehaviour
{
    private EnnemiPainted _ennemiPainted;
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _ennemiPainted.GetComponent<EnnemiPainted>();
        _ennemiPainted.EnnemiPaintedEvent += EnnemiPaintedAnimation;
    }

    public void EnnemiPaintedAnimation()
    {
        _animator.SetBool("IsPainted", true);
    }

    public void EnnemiAttackAnimation()
    {
        _animator.SetBool("Attack", true) ;
    }
}
