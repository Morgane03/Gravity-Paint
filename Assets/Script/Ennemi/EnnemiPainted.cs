using System;
using UnityEngine;

public class EnnemiPainted : MonoBehaviour
{
    public event Action EnnemiPaintedEvent;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Sword") && !EnnemiMain.Instance.IsPainted)
        {
            EnnemiMain.Instance.IsPainted = true;
            EnnemiPaintedEvent?.Invoke();
        }
    }
}
