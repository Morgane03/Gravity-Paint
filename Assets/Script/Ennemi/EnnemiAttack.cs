using UnityEngine;

public class EnnemiAttack : MonoBehaviour
{
    public bool InAttack;
    private EnnemiPainted _ennemiPainted;

    public void Start()
    {
        _ennemiPainted = GetComponent<EnnemiPainted>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_ennemiPainted.IsPainted)
        {
            InAttack = true;
            SoundManager.Instance.FrogAttack();
        }
    }
}
