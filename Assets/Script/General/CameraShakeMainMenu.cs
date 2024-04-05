using DG.Tweening;
using UnityEngine;

public class CameraShakeMainMenu : MonoBehaviour
{
    [SerializeField]
    private ChangeBackGround _changeBackGround;

    [SerializeField] 
    private float shakeDuration = 0.2f;
    [SerializeField]
    private float shakeAmount = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _changeBackGround.ChangeGround += ShakeCamera;
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
