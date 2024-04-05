using System.Collections;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    public event System.Action ChangeGround;

    [SerializeField]
    private GameObject _baseBackGround;

    [SerializeField]
    private GameObject _gravityBackGround;

    [SerializeField]
    private Color _color;

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
}
