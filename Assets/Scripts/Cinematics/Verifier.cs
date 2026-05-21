using JetBrains.Annotations;
using UnityEngine;

public class Verifier : MonoBehaviour
{
    public InventorySystem InventorySystem;
    public CinematicLauncher CinematicAccepted;
    public CinematicLauncher CinematicDenied;


    //Il vérifie une information à la demande d'un Launch Verifier et répond par lancer une fin de cinématique ou une autre.
    void Start()
    {
        InventorySystem = FindFirstObjectByType<InventorySystem>();
    }
    public void CheckSomething(string ItemSearched, int AmountRequired, CinematicLauncher CinematicA, CinematicLauncher CinematicB)
    {
        CinematicAccepted = CinematicA;
        CinematicDenied = CinematicB;
        if(InventorySystem == null)
        {
            CinematicDenied.Launch();
        }
    Item result = InventorySystem.inventory.Find(x => x.itemName == ItemSearched);
        if (result)
        {
            if (result.amount >= AmountRequired)
            {
                CinematicAccepted.Launch();
            }
            else
            {
                CinematicDenied.Launch();
            }
        }
        else
        {
            CinematicDenied.Launch();
        }
    }


}
