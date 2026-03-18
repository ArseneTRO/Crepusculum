using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image illustration;

    public Animator animator;

    private Queue<string> sentences;

    

    public static DialogueManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject); // doublon
        }

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        if (dialogue.sprite != null)
        {
            illustration.gameObject.SetActive(true);
            illustration.sprite = dialogue.sprite;
        }
        else
        {
            illustration.gameObject.SetActive(false); 
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
        {
        if (sentences.Count == 0)
        {
            EndDialogue();
            
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    void EndDialogue()
    {
        if (CinematicManager.Instance.fromCinematic)
        {
            CinematicManager.Instance.fromCinematic = false;
            CinematicManager.Instance.DisplayNextStep();
        }
        animator.SetBool("IsOpen", false);

    }
}
