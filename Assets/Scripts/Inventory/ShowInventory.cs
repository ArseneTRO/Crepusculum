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
    // gère le petit slot d'inventaire en bas à droite de l'écran dans le level 2
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
