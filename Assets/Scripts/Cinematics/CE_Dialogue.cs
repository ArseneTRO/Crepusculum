using UnityEngine;

public class CE_Dialogue : CinematicElement
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string[] sentences;
    [SerializeField]
    private string npcName;
    public PlayerMovement playerMovement;


    

    public override void PostStartProcess()
    {   
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerMovement.DialoguePlaying = true;
        Debug.Log("CE_Dialogue StartProcess appelé" + sentences[0]);
        DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
    }
    public override bool IsEnded()
    {
        Debug.Log("StartDialogue appelé, dialogueEnded = " + sentences[0]);
        return DialogueManager.Instance.IsDialogueEnded() /*&& Input.GetKeyDown(KeyCode.Space)*/;
        
    }
}
