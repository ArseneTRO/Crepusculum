using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;



public class CE_TP : CinematicElement
{
    
    public Vector3 tpPosition;
    public GameObject target;
    public bool isEnded;
    [SerializeField]
    private Transform targetTransform;
    public CE_CheckSomething check;
    public bool deniedCrew = false;
    private bool myDenied;

    public override void PostStartProcess()
    {
        check =  FindFirstObjectByType<CE_CheckSomething>();
        if (check == null)
        {
            myDenied = false;

            if (!myDenied)
            {
                isEnded = false;
                StartCoroutine(Teleportation());
            }
            else
            {
                isEnded = true;
                return;
            }
            return;
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
                isEnded = false;
                StartCoroutine(Teleportation());
            }
            else
            {
                print("J'ai fait mon taff Denied2 -Text");
                isEnded = true;
                return;
            }
        }
        else
        {
            if (!myDenied)
            {
                isEnded = false;
                StartCoroutine(Teleportation());
            }
            else
            {
                isEnded = true;
                return;
            }
        }
    }
    IEnumerator Teleportation()
    {
        targetTransform = target.GetComponent<Transform>();
        targetTransform.position = tpPosition;
        while (targetTransform.position != tpPosition)
        {
            yield return new WaitForEndOfFrame();
        }
        isEnded = true;
        yield break;
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
}
