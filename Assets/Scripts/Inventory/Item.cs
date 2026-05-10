using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int amount;
    public string itemDescription;
    public SpriteRenderer sprite;
    [SerializeField]
    private CircleCollider2D collider;

    public InventorySystem inventorySystem;
    public Item itemScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        Item existingItem = inventorySystem.Inventory.Find(x => x.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.amount += amount;
        }
        else
        {
            inventorySystem.Inventory.Add(this);
        }

        collider.enabled = false;
        sprite.enabled = false;
    }
}
