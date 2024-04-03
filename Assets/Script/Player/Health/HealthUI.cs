using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;

    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private Slider _backHealthSlider;

    [SerializeField]
    private int _updateDuration = 1;

    [SerializeField]
    private AnimationCurve _updateCurve;

    private void Awake()
    {
        _healthSlider.maxValue = _playerHealth.MaxHealth;
        _backHealthSlider.maxValue = _playerHealth.MaxHealth;
        _playerHealth.PlayerHealthChangedEvent += UpdateHealthUI;
    }

    public void UpdateHealthUI(int health)
    {
        Debug.Log("UpdateHealthUI: " + health);
        float startFillAmount = _healthSlider.value;
        float targetFillAmount = Mathf.Lerp(startFillAmount, health, _updateDuration);

        DOTween.Sequence()
            .Append(_healthSlider.DOValue(targetFillAmount, _updateDuration / 2f).SetEase(_updateCurve))
            .AppendInterval(0.5f)
            .Append(_backHealthSlider.DOValue(targetFillAmount, _updateDuration / 2f).SetEase(_updateCurve));
    }
}
