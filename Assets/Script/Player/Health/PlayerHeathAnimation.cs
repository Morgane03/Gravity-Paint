using System.Collections;
using UnityEngine;

public class PlayerHeathAnimation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private Animator _animator;

    [SerializeField]
    private ParticleSystem _particleSystem;

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
        Instantiate(_particleSystem, transform.position, Quaternion.Euler(-90, 0, 0));
        _particleSystem.Play();
    }

    private IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        _animator.SetBool("IsHurt", false);
    }
}
