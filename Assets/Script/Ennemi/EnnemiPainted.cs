using System;
using UnityEngine;

public class EnnemiPainted : MonoBehaviour
{
    public event Action EnnemiPaintedEvent;
    public bool IsPainted;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword") && !IsPainted)
        {
            IsPainted = true;
            EnnemiPaintedEvent?.Invoke();
        }
    }
}
