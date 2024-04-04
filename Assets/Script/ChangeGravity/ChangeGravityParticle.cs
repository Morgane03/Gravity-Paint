using System.Collections;
using UnityEngine;

public class ChangeGravityParticle : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _playerController.PlayerIsChangingGravityEvent += GravityParticule;
    }

    public void GravityParticule()
    {
        Instantiate(_particleSystem, _player.transform.position, Quaternion.Euler(-90, 0, 0));
        _particleSystem.Play();
        // trouver quand arreter particule
    }
}
