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
    public override void PostStartProcess()
    {
        dialogueText = CinematicManager.Instance.dialogueText;
        CinematicManager.Instance.CinematicUI = true;
        ended = false;
        StartCoroutine(TypeSentence(sentences));
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
        return ended && Input.GetKeyDown(KeyCode.Space);
    }
}
