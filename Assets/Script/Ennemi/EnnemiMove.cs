using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class EnnemiMove : MonoBehaviour
{
    public GameObject Player;
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

    private EnnemiAttack _ennemiAttack;

    public event Action CanAttackEvent;
    public event Action EnnemiWalkEvent;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ennemiAttack = GetComponent<EnnemiAttack>();

        _waypointTarget = _waypointsList[0];
    }

    public void Update()
    {
        if (!_ennemiAttack.InAttack)
        {
            EnnemiWalkEvent?.Invoke();

            _ennemiDirection = new Vector2(_waypointTarget.position.x - transform.position.x, 0);
            gameObject.transform.Translate(_ennemiDirection.normalized * _ennemiSpeed * Time.deltaTime, Space.World);
        }

        if (Vector2.Distance(transform.position, Player.transform.position) < _distanceToFollowPlayer)
        {
            _waypointTarget = Player.transform;

            if (Vector2.Distance(transform.position, Player.transform.position) < 5f)
            {
                gameObject.transform.Translate(Vector2.zero, Space.World);
                CanAttackEvent.Invoke();
            }
        }

        else if (Vector2.Distance(transform.position, _waypointTarget.position) < 1f)
        {
            _targetNumber = (_targetNumber + 1) % _waypointsList.Count;
            _waypointTarget = _waypointsList[_targetNumber];
        }

        else if (Vector2.Distance(transform.position, Player.transform.position) > _distanceToFollowPlayer)
        {
            _ennemiAttack.InAttack = false;

            if (Vector2.Distance(transform.position, Player.transform.position) > _distanceToFollowPlayer * 2)
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