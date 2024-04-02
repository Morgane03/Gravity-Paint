using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action PlayerIsDeadEvent;
    public event Action<int> PlayerHealthChangedEvent;

    private PlayerController _playerController;

    [SerializeField]
    private int _maxHealth = 100;
    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !_playerController.IsPainting)
        {
            _currentHealth -= 10;
            PlayerHealthChangedEvent?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                OnPlayerIsDead();
            }
        }
    }

    private void OnPlayerIsDead()
    {
        PlayerIsDeadEvent?.Invoke();
    }
}
