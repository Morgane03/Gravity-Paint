using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private Slider _backHealthSlider;

    [SerializeField]
    private int _updateDuration = 1;

    [SerializeField]
    private AnimationCurve _updateCurve;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _healthSlider.maxValue = _playerHealth.MaxHealth;
        _backHealthSlider.maxValue = _playerHealth.MaxHealth;
        _playerHealth.PlayerHealthChangedEvent += UpdateHealthUI;
    }

    public void UpdateHealthUI(int health)
    {
        //StartCoroutine(UpdateHealthSlider(health, _updateDuration));
        float startFillAmount = _healthSlider.value;
        float targetFillAmount = Mathf.Lerp(startFillAmount, health, _updateDuration); //Mathf.InverseLerp(0, _playerHealth.MaxHealth, health);


        DOTween.Sequence()
            .Append(_healthSlider.DOValue(targetFillAmount, _updateDuration / 2f).SetEase(_updateCurve))
            .AppendInterval(0.5f)
            .Append(_backHealthSlider.DOValue(targetFillAmount, _updateDuration / 2f).SetEase(_updateCurve));
    }

    //private IEnumerator UpdateHealthSlider(int health, int duration)
    //{
    //    float startFillAmount = _healthSlider.value;
    //    float timer = 0;

    //    while (timer < duration)
    //    {
    //        timer += Time.deltaTime;
    //        _healthSlider.value = Mathf.Lerp(startFillAmount, health, _updateCurve.Evaluate(timer / duration));
    //        yield return null;
    //    }
    //}
}
