using UnityEngine;

public class CE_CheckSomething : CinematicElement
{
    private bool checkup;
    private string itemNameCheck;
    public bool isEnded;
    public bool isDenied = false;
    public InventorySystem inventorySystem;
    public bool iDidMyRole = false;

    public override void PostStartProcess()
    {
        inventorySystem = FindFirstObjectByType<InventorySystem>();
        isEnded = false;
        Item result = inventorySystem.Inventory.Find(x => x.itemName == itemNameCheck);
        if (result)
        {
            checkup = true;
        }
        Continue();
    }
public void Continue()
{
    if (checkup)
     {
        isDenied = false;
        iDidMyRole = true;
    }
    else
     {
        isDenied = true;
        iDidMyRole = true;
    }
    isEnded = true;
     return;
}

    public override bool IsEnded()
    {
        return isEnded;
    }
}
