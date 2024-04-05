using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    public void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }

    [SerializeField] private AudioSource _footStepsPlayer;
    [SerializeField] private AudioSource _frogCroaking;
    [SerializeField] private AudioSource _glitterEffects;

    public void FootStepsPlayer()
    {
        _footStepsPlayer.Play();
    }

    public void StopFootStepsPlayer()
    {
        _footStepsPlayer.Stop();
    }

    public void GlitterEffect()
    {
        _glitterEffects.Play();
    }

    public void FrogCroaking()
    {
        _frogCroaking.Play();   
    }
}
