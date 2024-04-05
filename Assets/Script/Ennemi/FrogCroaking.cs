using System.Collections;
using UnityEngine;

public class FrogCroaking : MonoBehaviour
{
    public int WaitCroaking;

    public void Start()
    {
        StartCoroutine(Croaking());
    }

    IEnumerator Croaking()
    {
        SoundManager.Instance.FrogCroaking();
        yield return new WaitForSeconds(WaitCroaking);
        StartCoroutine(Croaking());
    }
}
