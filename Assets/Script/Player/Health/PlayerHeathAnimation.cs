using System.Collections;
using UnityEngine;

public class PlayerHeathAnimation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private Animator _animator;

    [SerializeField]
    private ParticleSystem _particleSystem;

    private Camera _camera;
    private float _duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
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
        StartCoroutine(ZoomToDeath());
        Instantiate(_particleSystem, transform.position, Quaternion.Euler(-90, 0, 0));
        _particleSystem.Play();
    }

    private IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        _animator.SetBool("IsHurt", false);
    }

    private IEnumerator ZoomToDeath()
    {
        float initialSize = _camera.orthographicSize;
        float time = 0;

        while (time < _duration)
        {
            _camera.orthographicSize = Mathf.Lerp(initialSize, 5, time / _duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
