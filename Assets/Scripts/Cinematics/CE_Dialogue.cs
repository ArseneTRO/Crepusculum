using UnityEngine;

public class CE_Dialogue : CinematicElement
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string[] sentences;
    [SerializeField]
    private string npcName;


    //lance un dialogue dans une cinématique

    public override void PostStartProcess()
    {
        DialogueManager.Instance.StartDialogue(new Dialogue { name = npcName, sentences = sentences, sprite = sprite});
    }
    public override bool IsEnded()
    {
        return DialogueManager.Instance.IsDialogueEnded() && Input.GetKeyDown(KeyCode.Space);
    }
}
