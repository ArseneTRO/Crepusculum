using Unity.VectorGraphics;
using UnityEngine;

public class CE_LaunchVerifier : CinematicElement
{
    public string ItemSearched;
    public int AmountRequired;
    public Verifier Verifier;
    public CinematicLauncher Accepted;
    public CinematicLauncher Denied;
    public bool isEnded;


    //lance le vérifieur, lui pose une question qui reviens true ou false
    public override void PostStartProcess()
    {
        isEnded = false;
        StartCheck();
    }

    void StartCheck()
    {
        Verifier.CheckSomething(ItemSearched, AmountRequired, Accepted, Denied);
        isEnded = true;
    }
    public override bool IsEnded()
    {
        return isEnded;
    }
}
