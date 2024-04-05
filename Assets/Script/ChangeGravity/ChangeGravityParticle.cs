using UnityEngine;

public class ChangeGravityParticle : MonoBehaviour
{
    [SerializeField]
    private PlayerChangeGravity _playerChangeGravity;

    [SerializeField]
    private ParticleSystem _gravityParticleSystem;

    [SerializeField]
    private ParticleSystem _flipParticleSystem;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _globalVolume;

    void Start()
    {
        _gravityParticleSystem.Stop();
        _flipParticleSystem.Stop();
        _playerChangeGravity.PlayerChangeGravityUp += GravityParticule;
        _playerChangeGravity.PlayerChangeGravityDown += StopGravityParticle;
    }

    public void GravityParticule()
    {
        _globalVolume.SetActive(true);
        _flipParticleSystem.Stop();
        FlipPlayer();
        _gravityParticleSystem.transform.position = new Vector3(_player.transform.position.x - 0.8f, _player.transform.position.y -6.29f, 0);
        _gravityParticleSystem.Play();
    }

    private void StopGravityParticle()
    {
        _flipParticleSystem.Stop();
        FlipPlayer();
        _gravityParticleSystem.Stop();
        _globalVolume.SetActive(false);
    }

    private void FlipPlayer()
    {
        _flipParticleSystem.Play();
        _flipParticleSystem.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, 0);
    }
}
