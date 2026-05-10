using UnityEngine;

public class CE_MouvementByGo : CinematicElement
{
    public GameObject target;
    public GameObject PositionEnd;
    public float moveSpeed;
    public bool isEnded;

    public override void PostStartProcess()
    {
        isEnded = false;
        StartCoroutine(CinematicMouvement());
    }
    IEnumerator CinematicMouvement()
    {
//////////////////////////////////////////////////////CODE A FAIRE
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
