using UnityEngine;

public class CE_Dialogue : CinematicElement
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string[] sentences;
    [SerializeField]
    private string npcName;
    public CE_CheckSomething check;
    public bool deniedCrew = false;
    public bool myDenied;
    public bool ended;

   
    public override void PostStartProcess()
    {
        check =  FindFirstObjectByType<CE_CheckSomething>();
        if (check == null)
        {
            myDenied = false;

            if (!myDenied)
            {
                DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
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
                DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
            }
            else
            {
                ended = true;
                return;
            }
        }
        
        else
        {
            if (!myDenied)
            {
                DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
            }
            else
            {
                
                ended = true;
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
                return ended && DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
                
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
                return ended && DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
                
            }
            else
            {
        
                return ended;
            }
        }
        
    }
        
}
