using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerHealth _playerHealth;

    // For gravity change
    private readonly float shakeAmount = 10f;
    private readonly float shakeDuration = 0.2f;

    // For player touch
    private readonly float duration = 0.3f; // Dur�e de l'effet de shake
    private readonly float strength = 0.3f; // Force du shake

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _playerHealth = GetComponentInParent<PlayerHealth>();
        originalPosition = transform.localPosition;
        _playerController.PlayerIsChangingGravityEvent += ShakeCamera;
        _playerController.PlayerIsPaintingEvent += Playerattack;
        _playerHealth.PlayerTuchEvent += PlayerTuch;
    }

    void ShakeCamera()
    {
        float randomAngle = Random.Range(-shakeAmount, shakeAmount);

        transform.DORotate(new Vector3(0, 0, randomAngle), shakeDuration).OnComplete(() =>
        {
            transform.DORotate(Vector3.zero, shakeDuration); //Remet la cam�ra � sa position initiale
        });
    }

    void PlayerTuch()
    {
        transform.DOShakePosition(duration, strength).OnComplete(() =>
        {
            transform.localPosition = originalPosition;
        });
    }

    void Playerattack()
    {
        transform.DOShakePosition(shakeDuration, new Vector3(strength, 0, 0), vibrato: 10, randomness: 90, fadeOut: true).OnComplete(() =>
        {
            transform.localPosition = originalPosition;
        });
    }
}
