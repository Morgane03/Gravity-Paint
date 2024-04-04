using UnityEngine;

public class EnnemiMain : MonoBehaviour
{
    private static EnnemiMain _instance;
    public static EnnemiMain Instance { get { return _instance; } }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public bool IsPainted;

    public EnnemiAnimation EnnemiAnimation;
    public EnnemiMove EnnemiMove;
    public EnnemiAttack EnnemiAttack;
    public EnnemiPainted EnnemiPainted;
}
