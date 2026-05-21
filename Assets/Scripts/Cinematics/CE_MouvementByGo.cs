using UnityEngine;
using System.Collections;

public class CE_MouvementByGo : CinematicElement
{
    public GameObject target;
    public GameObject PositionEnd;
    public float moveSpeed;
    public bool isEnded;

    //déplace la target à la position d'un gameobject précis
    public override void PostStartProcess()
    {
        isEnded = false;
        StartCoroutine(CinematicMouvement());
    }
    IEnumerator CinematicMouvement()
    {
        if (target == null || PositionEnd == null) { isEnded = true; yield break; }
        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        float distance = Vector2.Distance(PositionEnd.transform.position, target.transform.position);
        while (distance > 0.3f)
        {
            Vector2 dirToTarget = ((Vector2)PositionEnd.transform.position - (Vector2)target.transform.position).normalized;
            targetRb.linearVelocity = dirToTarget * moveSpeed;
            distance = Vector2.Distance(PositionEnd.transform.position, target.transform.position);
            print(distance);
            yield return new WaitForFixedUpdate();
        }
        targetRb.linearVelocity = Vector2.zero;
        isEnded = true;
        yield break;
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
