using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;
    public PlayerMovement playerMovement;
    //public bool CanSkip = true;


     void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        //CanSkip = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && playerMovement.CinematicPlaying == false)
        {
            TriggerDialogue();
            playerMovement.DialoguePlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) /*&& CanSkip && playerMovement.DialoguePlaying*/)
        {
                StartCoroutine(DispNextSentence());
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    void DisplayNextSentence()
    {
        StartCoroutine(DispNextSentence());
    }
    IEnumerator DispNextSentence()
    {
        DialogueManager.Instance.DisplayNextSentence();
            yield return new WaitForSeconds(1f);

        yield break;

    }
}
