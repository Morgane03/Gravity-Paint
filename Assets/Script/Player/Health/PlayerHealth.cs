using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action PlayerIsDeadEvent;
    public event Action<int> PlayerHealthChangedEvent;

    private PlayerController PlayerController { get { return GetComponent<PlayerController>(); } set { } }

    public int MaxHealth = 100;
    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = MaxHealth;
        PlayerHealthChangedEvent?.Invoke(_currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        _currentHealth -= 10;
    //        PlayerHealthChangedEvent?.Invoke(_currentHealth);

    //        if (_currentHealth <= 0)
    //        {
    //            OnPlayerIsDead();
    //        }
    //    }
    //}
}
