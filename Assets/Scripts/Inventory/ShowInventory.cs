using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    public InventorySystem InventorySystem;
    [SerializeField]
    private TextMeshProUGUI _count;
    [SerializeField]
    private Image _image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InventorySystem == null) return;
        if (InventorySystem.inventory == null) return;
        if (InventorySystem.inventory.Count == 0)
        {
            _image.color = new UnityEngine.Color(0f, 0f, 0f, 0f);
            _count.color = new UnityEngine.Color(0f, 0f, 0f, 0f);
            return;
        }
        else
        {
            _image.color = new UnityEngine.Color(255f, 255f, 255f, 255f);
            _count.color = new UnityEngine.Color(255f, 255f, 255f, 255f);
        }
    }

    public void UpdateItem()
    {
        _image.sprite = InventorySystem.inventory[0].sprite.sprite;
        _count.text = (InventorySystem.inventory[0].amount).ToString();
    }
}
