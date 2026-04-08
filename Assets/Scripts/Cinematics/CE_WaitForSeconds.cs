using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class CE_WaitForSeconds : CinematicElement
{
    [SerializeField]
    public int timeToWait;
    public bool isEnded;

    public override void PostStartProcess()
    {
        StartCoroutine(Wait());
    }

    public override bool IsEnded()
    {
        return isEnded;  // Sans les parenthèses !
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToWait);
        isEnded = true;
        yield break;
    }
}
