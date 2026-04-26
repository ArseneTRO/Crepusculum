using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class CE_Trigger : CinematicElement
{
    [SerializeField]
    private Animator myAnimator;
    public string myBool;
    public bool isEnded;
    public CE_CheckSomething check;
    public bool deniedCrew = false;
    private bool myDenied;

    public override void PostStartProcess()
    {
        check =  FindFirstObjectByType<CE_CheckSomething>();
        if (check == null)
        {
            myDenied = false;
        }
        myDenied = check.isDenied;
        if (!check.iDidMyRole)
        {
            myDenied = false;
        }
        if (deniedCrew)
        {
            if (myDenied)
            {
                StartCoroutine(Trigger());
            }
            else
            {
                return;
            }
        }
        else
        {
            if (!myDenied)
            {
                StartCoroutine(Trigger());
            }
            else
            {
                return;
            }
        }
    }

    public override bool IsEnded()
    {
        if (deniedCrew)
        {
            if (myDenied)
            {
                return isEnded && DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
                
            }
            else
            {
                return isEnded;
            }
        }
        else
        {
            if (!myDenied)
            {
                return isEnded && DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
                
            }
            else
            {
        
                return isEnded;
            }
        }
        
    }

    IEnumerator Trigger()
    {
        Debug.Log("PostStartProcess appel� !");
        isEnded = false;
        myAnimator.SetBool(myBool, true);
        Debug.Log($"SetBool appel� : {myBool} = true sur {myAnimator.gameObject.name}");
        yield return new WaitForSeconds(0.5f);
        isEnded = true;
        yield break;
    }
}
