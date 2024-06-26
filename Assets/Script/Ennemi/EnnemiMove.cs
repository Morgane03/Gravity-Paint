using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class EnnemiMove : MonoBehaviour
{
    public GameObject SpawnPointPlayer;
    [SerializeField]
    private int _distanceToFollowPlayer;

    [SerializeField]
    private List<Transform> _waypointsList = new List<Transform>();
    private Transform _waypointTarget;
    private int _targetNumber;

    [SerializeField]
    private int _ennemiSpeed;
    private Vector2 _ennemiDirection;
    private SpriteRenderer _spriteRenderer;

    private GameObject _exclamationPoint;

    public event Action CanAttackEvent;
    public event Action EnnemiWalkEvent;

    private EnnemiPainted _ennemiPainted;
    private EnnemiAttack _ennemiAttack;

    void Start()
    {
        _exclamationPoint = transform.GetChild(0).gameObject;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ennemiPainted = GetComponent<EnnemiPainted>();
        _ennemiAttack = GetComponent<EnnemiAttack>();

        _waypointTarget = _waypointsList[0];
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _waypointTarget = _waypointsList[_targetNumber];
        }
    }
    public void Update()
    {
        if (!_ennemiPainted.IsPainted)
        {
            if (!_ennemiAttack.InAttack)
            {
                EnnemiWalkEvent?.Invoke();

                _ennemiDirection = new Vector2(_waypointTarget.position.x - transform.position.x, 0);
                gameObject.transform.Translate(_ennemiDirection.normalized * _ennemiSpeed * Time.deltaTime, Space.World);
            }

            if (Vector2.Distance(transform.position, SpawnPointPlayer.transform.position) < _distanceToFollowPlayer)
            {
                if (Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, SpawnPointPlayer.transform.position.y)) < 1f)
                {
                    StartCoroutine(ShowExclamationPoint());
                    _waypointTarget = SpawnPointPlayer.transform;

                    if (Vector2.Distance(transform.position, SpawnPointPlayer.transform.position) < 3f)
                    {
                        gameObject.transform.Translate(Vector2.zero, Space.World);
                        CanAttackEvent.Invoke();
                    }
                }
            }

            else if (Vector2.Distance(transform.position, _waypointTarget.position) < 1f)
            {
                _targetNumber = (_targetNumber + 1) % _waypointsList.Count;
                _waypointTarget = _waypointsList[_targetNumber];
                SoundManager.Instance.StopFrogAttack();
            }

            else if (Vector2.Distance(transform.position, SpawnPointPlayer.transform.position) > _distanceToFollowPlayer)
            {
                _ennemiAttack.InAttack = false;

                if (Vector2.Distance(transform.position, SpawnPointPlayer.transform.position) > _distanceToFollowPlayer * 2)
                {
                    _waypointTarget = _waypointsList[_targetNumber];
                }
            }

            if (_ennemiDirection.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            if (_ennemiDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    }

    IEnumerator ShowExclamationPoint()
    {
        _exclamationPoint.SetActive(true);
        yield return new WaitForSeconds(2);
        _exclamationPoint.SetActive(false);
    }
}