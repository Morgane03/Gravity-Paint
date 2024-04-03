using System.Collections;
using UnityEngine;

public class PlayerPaint : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _playerController.PlayerIsPaintingEvent += Paint;
    }

    public void Paint()
    {
        _playerController.IsPainting = true;
        _animator.SetBool("Paint", true);
        StartCoroutine(StopPaint());
    }

    private IEnumerator StopPaint()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Paint", false);
        _playerController.IsPainting = false;
    }
}
