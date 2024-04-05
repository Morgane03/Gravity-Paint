using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public event Action PlayerIsDeadEvent;
    public event Action<int> PlayerHealthChangedEvent;
    public event Action PlayerTuchEvent;

    private PlayerController PlayerController;

    public int MaxHealth = 100;
    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        _currentHealth = MaxHealth;
        PlayerHealthChangedEvent?.Invoke(_currentHealth);
        PlayerTuchEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !PlayerController.IsPainting)
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentHealth -= 10;
            PlayerHealthChangedEvent?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                OnPlayerIsDead();
            }
        }
    }
}
