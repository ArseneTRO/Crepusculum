using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;
    public PlayerMovement playerMovement;


     void Start()
    {
        if (boxCollider2D == null)
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    //Ce script permet de lancer un dialogue lorsqu'on est dans la range d'un pnj et qu'il as un dialogue. Il gère aussi le défilement des dialogues en appuyant sur espace en fonction des situation (si on est en dialogue ou en cinématique, le joueur ne bouge pas
    //donc on utilise espace, car de toute manière il ne peux pas sauter. Si le joueur peut sauter,on utilise E, pour éviter qu'il skip un dialogue involontairement en sautant)
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && playerMovement.CinematicPlaying == false)
        {
            TriggerDialogue();
            playerMovement.DialoguePlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (playerMovement.CinematicPlaying || playerMovement.DialoguePlaying) && !DialogueManager.Instance.isDiscovery)
        {
                StartCoroutine(DispNextSentence());
        }
                if (Input.GetKeyDown(KeyCode.E) && !playerMovement.CinematicPlaying && !playerMovement.DialoguePlaying)
        {
                StartCoroutine(DispNextSentence());
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isInRange = true;
            print("Why is in range isnt working");
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
