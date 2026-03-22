using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;
    public PlayerMovement playerMovement;

     void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && playerMovement.CinematicPlaying == false)
        {
            TriggerDialogue();
            playerMovement.DialoguePlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
        if (playerMovement.CinematicPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
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
    DialogueManager.Instance.DisplayNextSentence();
    }
}
