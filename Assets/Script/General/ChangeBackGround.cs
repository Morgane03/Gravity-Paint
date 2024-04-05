using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackGround : MonoBehaviour
{
    public event System.Action ChangeGround;

    [SerializeField]
    private GameObject _baseBackGround;

    [SerializeField]
    private GameObject _gravityBackGround;

    [SerializeField]
    private List<Button> _buttonList;

    // Start is called before the first frame update
    void Start()
    {
        _baseBackGround.SetActive(true);
        _gravityBackGround.SetActive(false);
        StartCoroutine(ChangeBackground());
    }

    private IEnumerator ChangeBackground()
    {
        yield return new WaitForSeconds(3);
        ChangeGround?.Invoke();
        int time = Random.Range(1, 3);
        yield return new WaitForSeconds(time);
        SwitchBackground();
    }

    private void SwitchBackground()
    {
        _baseBackGround.SetActive(!_baseBackGround.activeSelf);
        _gravityBackGround.SetActive(!_gravityBackGround.activeSelf);
        StartCoroutine(ChangeBackground());
    }

    public void CreditActive()
    {
        StopCoroutine(ChangeBackground());
    }

    public void CreditDesactive()
    {
        StartCoroutine(ChangeBackground());
    }
}
