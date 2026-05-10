using UnityEngine;
using System.Collections;

public class CE_Credits : CinematicElement
{
    public Animator AllCredits;
    public bool isEnded;

    public override void PostStartProcess()
    {
        StartCoroutine(StartCredits());
    }

    IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(2);
        AllCredits.SetBool("Credits", true);
        yield return new WaitForSeconds(62);
        isEnded = true;
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
