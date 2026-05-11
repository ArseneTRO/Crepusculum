using UnityEngine;
using System.Collections;

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
        while (target.transform.position.x > PositionEnd.transform.position.x)
        {
            target.transform.position = new Vector3(Mathf.Lerp(target.transform.position.x, PositionEnd.transform.position.x, 0.2f), Mathf.Lerp(target.transform.position.y, PositionEnd.transform.position.y, 0.2f), 0);
            yield return null;
        }
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
