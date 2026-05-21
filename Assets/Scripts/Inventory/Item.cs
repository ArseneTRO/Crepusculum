using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int amount;
    public string itemDescription;
    public SpriteRenderer sprite;
    [SerializeField]
    private CircleCollider2D collider;
    public ShowInventory showInventory;

    public InventorySystem inventorySystem;
    public Item itemScript;
    // Définit ce qu'est un Item dans l'inventaire et ce qu'il contient comme info
    void Start()
    {
        inventorySystem = FindAnyObjectByType<InventorySystem>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Item existingItem = inventorySystem.inventory.Find(x => x.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.amount += amount;
            showInventory.UpdateItem();
        }
        else
        {
            inventorySystem.inventory.Add(this);
            showInventory.UpdateItem();
        }

        collider.enabled = false;
        sprite.enabled = false;
    }
}
