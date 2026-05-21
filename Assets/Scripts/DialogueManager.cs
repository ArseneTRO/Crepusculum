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
    public PlayerMovement playerMovement;
    public DialogueTrigger trigger;
    public Animator animator;
    public PauseSystem PauseSystem;
    public GameObject spaceIndicator;
    public GameObject eIndicator;

    private Queue<string> sentences;
    public List<Dialogue> dialogues;
    public bool isDiscovery = false;
    private bool canDisplay;

    private bool dialogueEnded = true;



    public bool IsDialogueEnded()
    {
        return dialogueEnded && Input.GetKeyDown(KeyCode.Space);
    }

    public static DialogueManager Instance;
    private void Awake()
    {
        PauseSystem = FindFirstObjectByType<PauseSystem>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
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

    public void StartDialogue(Dialogue dialogue, bool Discovery = false)
    {
        if (!dialogueEnded)
        {
            return;    
        }

        dialogueEnded = false;
        isDiscovery = Discovery;
        animator.SetBool("IsOpen", true);
        if(Discovery)
        {
            eIndicator.SetActive(true);
            spaceIndicator.SetActive(false);
            print("C'est E!");
        }
        else
        {
            spaceIndicator.SetActive(true);
            eIndicator.SetActive(false);
            print("c'est Space");
        }
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
        if (!PauseSystem.isPaused)
        {
            StopAllCoroutines();
            StartCoroutine(NextSentence());
        }
    }

    IEnumerator NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            yield break;
        }
        
        string sentence = sentences.Dequeue();
        
        print(sentences.Count);
        StartCoroutine(TypeSentence(sentence));
        
        
        yield break;
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        
    }


    public void EndDialogue()
    {
        dialogueEnded =true;   
        spaceIndicator.SetActive(false); 
        eIndicator.SetActive(false); 
        animator.SetBool("IsOpen", false);
        playerMovement.DialoguePlaying = false;
    }
}
