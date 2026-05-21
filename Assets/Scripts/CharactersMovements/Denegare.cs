using System.Collections;
using UnityEngine;

public class Denegare : MonoBehaviour
{
    public Dialogue dialogueDenied;
    public Dialogue dialogueNotEnough;
    public Dialogue dialogueAccepted;
    public Dialogue dialogueAlreadyDone;

    public bool isInRange;
    public BoxCollider2D boxCollider2D;
    public PlayerMovement playerMovement;
    public InventorySystem inventorySystem;
    public Item denKey;
    public ShowInventory showInventory;
    //Le script permet de faire fonctionner le pnj Denegare. Il va adapter son dialogue en fonction des circonstances. Il doit vérifier si le joueur a le bon item en bonne quantité, et donne la réponse en conséquence.


    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        inventorySystem = FindFirstObjectByType<InventorySystem>();
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
        Item result = inventorySystem.inventory.Find(x => x.itemName == "Chaussons aux pommes");
        Item resultBis = inventorySystem.inventory.Find(x => x.itemName == "Clé de Den");
        if (result)
        {
            if (result.amount < 7)
            {
                DialogueManager.Instance.StartDialogue(dialogueNotEnough);
            }
            else 
            {
                DialogueManager.Instance.StartDialogue(dialogueAccepted);
                inventorySystem.inventory.Add(denKey);
                inventorySystem.inventory.Remove(result);
                showInventory.UpdateItem();
            }
        }
        else
        {
            if(!result && !resultBis)
            {
                DialogueManager.Instance.StartDialogue(dialogueDenied);
            }
            if (resultBis && !result)
            {
                DialogueManager.Instance.StartDialogue(dialogueAlreadyDone);
            }
            print("Item unfound");
        }

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
