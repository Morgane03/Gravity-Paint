using System;
using UnityEngine;

public class EnnemiPainted : MonoBehaviour
{
    public event Action EnnemiPaintedEvent;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EnnemiPaintedEvent?.Invoke();
        }
    }
}
