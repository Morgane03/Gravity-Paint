using UnityEngine;

public class EnnemiAttack : MonoBehaviour
{
    public bool InAttack;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InAttack = true;
        }
    }
}
