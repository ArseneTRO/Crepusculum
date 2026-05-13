using UnityEngine;
using System.Collections;

public class CE_Trigger : CinematicElement
{
    [SerializeField]
    private Animator myAnimator;
    public string myBool;
    public bool isEnded;

    public override void PostStartProcess()
    {
        StartCoroutine(Trigger());
    }

    public override bool IsEnded()
    {
        return isEnded;
    }

    IEnumerator Trigger()
    {
        Debug.Log("PostStartProcess appelé !");
        isEnded = false;
        myAnimator.SetBool(myBool, true);
        Debug.Log($"SetBool appelé : {myBool} = true sur {myAnimator.gameObject.name}");
        yield return new WaitForSeconds(0.5f);
        isEnded = true;
        yield break;
    }
}
