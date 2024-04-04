using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private PlayerController _playerController;

    public float shakeAmount = 10f;
    public float shakeDuration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _playerController.PlayerIsChangingGravityEvent += ShakeCamera;
    }

    void ShakeCamera()
    {
        float randomAngle = Random.Range(-shakeAmount, shakeAmount);

        transform.DORotate(new Vector3(0, 0, randomAngle), shakeDuration).OnComplete(() =>
        {
            transform.DORotate(Vector3.zero, shakeDuration); //Remet la caméra à sa position initiale
        });
    }
}
