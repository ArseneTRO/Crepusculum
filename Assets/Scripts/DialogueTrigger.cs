using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;
    public PlayerMovement playerMovement;
    public bool isCinematic;
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
        Debug.Log(playerMovement.DialoguePlaying);
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !playerMovement.CinematicPlaying)
        {
            TriggerDialogue();
            playerMovement.DialoguePlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.DialoguePlaying && !playerMovement.CinematicPlaying)
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
    public void DisplayNextSentence()
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
