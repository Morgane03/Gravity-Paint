using System.Collections;
using UnityEngine;

public class ChangeGravityParticle : MonoBehaviour
{
    [SerializeField]
    private PlayerChangeGravity _playerChangeGravity;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem.Stop();
        _playerChangeGravity.PlayerChangeGravityUp += GravityParticule;
    }

    public void GravityParticule()
    {
        //Instantiate(_particleSystem, _player.transform.position, Quaternion.Euler(-90, 0, 0));
        _particleSystem.transform.position = new Vector3(_player.transform.position.x - 0.8f, _player.transform.position.y -6.29f, 0);
        _particleSystem.Play();
        // trouver quand arreter particule bool
    }

    private void StopGravityParticle()
    {
        _particleSystem.Stop();
    }
}
