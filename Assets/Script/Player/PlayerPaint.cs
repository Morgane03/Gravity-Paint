using System.Collections;
using UnityEngine;

public class PlayerPaint : MonoBehaviour
{
    //private Collider2D _collider2D;

    //private Vector2 _size;
    //private Vector2 _baseSize;

    private PlayerController _playerController;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        //_collider2D = GetComponent<Collider2D>();
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        //_size = _collider2D.bounds.size;
        //_baseSize = _size;
        _playerController.PlayerIsPaintingEvent += Paint;
    }

    public void Paint()
    {
        _animator.SetBool("Paint", true);
        //_size = new Vector2(5.5205f, _size.y);
        StartCoroutine(StopPaint());
    }

    private IEnumerator StopPaint()
    {
        yield return new WaitForSeconds(0.5f);
        //_size = _baseSize;
        _animator.SetBool("Paint", false);
    }
}
