using System.Collections;
using UnityEngine;

public class PlayerHeathAnimation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _playerHealth.PlayerHealthChangedEvent += DamageAnimation;
        _playerHealth.PlayerIsDeadEvent += DeathAnimation;
    }

    public void DamageAnimation(int health)
    {
        if(health < _playerHealth.MaxHealth)
        {
            _animator.SetBool("IsHurt", true);
            StartCoroutine(ResetHurtAnimation());
        }
        else
        {
            _animator.SetBool("IsHurt", false);
        }
    }

    public void DeathAnimation()
    {
        _animator.SetBool("IsDead", true);
    }

    private IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        _animator.SetBool("IsHurt", false);
    }
}
