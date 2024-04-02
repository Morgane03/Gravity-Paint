using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.PlayerHealthChangedEvent += UpdateHealthUI;
    }

    public void UpdateHealthUI(int health)
    {
        Debug.Log("Health: " + health);
    }
}
