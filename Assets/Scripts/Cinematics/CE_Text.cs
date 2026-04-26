using UnityEditor.Rendering;
using System.Collections;
using UnityEngine;
using TMPro;

public class CE_Text : CinematicElement
{
    [SerializeField]
    private string sentences;
    private TMP_Text dialogueText;
    private bool ended;
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
                dialogueText = CinematicManager.Instance.dialogueText;
                CinematicManager.Instance.CinematicUI = true;
                ended = false;
                StartCoroutine(TypeSentence(sentences));
                print("J'ai fait mon taff null1 -Text");
            }
            else
            {
                ended = true;
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
                dialogueText = CinematicManager.Instance.dialogueText;
                CinematicManager.Instance.CinematicUI = true;
                ended = false;
                StartCoroutine(TypeSentence(sentences));
                
            }
            else
            {
                print("J'ai fait mon taff Denied2 -Text");
                ended = true;
                return;
            }
        }
        else
        {
            if (!myDenied)
            {
                dialogueText = CinematicManager.Instance.dialogueText;
                CinematicManager.Instance.CinematicUI = true;
                ended = false;
                StartCoroutine(TypeSentence(sentences));
                
            }
            else
            {
                
                ended = true;
                return;
            }
        }
        
    }

    IEnumerator TypeSentence(string CinematicSentence)
    {
        dialogueText.text = "";
        foreach (char letter in CinematicSentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        ended = true;
    }


    public override bool IsEnded()
    {
        if (deniedCrew)
        {
            if (myDenied)
            {
                return ended && Input.GetKeyDown(KeyCode.Space);
                
            }
            else
            {
                return ended;
            }
        }
        else
        {
            if (!myDenied)
            {
                return ended && Input.GetKeyDown(KeyCode.Space);
                
            }
            else
            {
        
                return ended;
            }
        }
        
    }
}
