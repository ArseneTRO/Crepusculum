using UnityEngine;
using System.Collections;

public class CE_Movement : CinematicElement
{
    public Vector2 positionStart;
    public Vector2 positionEnd;
    public GameObject target;
    public float moveSpeed;
    public bool isEnded;

    //Déplace la target à une position précise

    public override void PostStartProcess()
    {
        isEnded = false;
        StartCoroutine(CinematicMouvement());
    }
    IEnumerator CinematicMouvement()
    {

        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        float distance = Vector2.Distance(positionEnd, positionStart);
        while (distance > 0.3f)
        {
            Vector2 dirToTarget = (positionEnd - (Vector2)target.transform.position).normalized;
            targetRb.linearVelocity = dirToTarget * moveSpeed;
            distance = Vector2.Distance(positionEnd, target.transform.position);
            yield return new WaitForEndOfFrame();
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
