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
                DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
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
                DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
            }
            else
            {
                return;
            }
        }
        
    }
    public override bool IsEnded()
    {
        return DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
    }
}
