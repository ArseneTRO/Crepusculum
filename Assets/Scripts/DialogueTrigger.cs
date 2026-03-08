using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
        if (Input.GetKeyDown(KeyCode.R))
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
