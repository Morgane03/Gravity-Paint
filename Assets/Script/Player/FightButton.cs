using UnityEngine;

public class FightButton : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _changeScene.OnClick();
    }
}
