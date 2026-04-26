using UnityEngine;
using System.Collections;

public class CE_Movement : CinematicElement
{
    public Vector2 positionStart;
    public Vector2 positionEnd;
    public GameObject target;
    public float moveSpeed;
    public bool isEnded;
    public CE_CheckSomething check;
    public bool deniedCrew = false;
    private bool myDenied;

    public override void PostStartProcess()
    {
        check =  FindFirstObjectByType<CE_CheckSomething>();
        if (check == null)
        {
            myDenied = false;

            if (!myDenied)
            {
                isEnded = false;
                StartCoroutine(CinematicMouvement());
            }
            else
            {
                isEnded = true;
                return;
            }
            return;
        }
        myDenied = check.isDenied;
        if (!check.iDidMyRole)
        {
            myDenied = false;
        }
        if (deniedCrew)
        {
            if (myDenied)
            {
                isEnded = false;
                StartCoroutine(CinematicMouvement());
            }
            else
            {
                print("J'ai fait mon taff Denied2 -Text");
                isEnded = true;
                return;
            }
        }
        else
        {
            if (!myDenied)
            {
                isEnded = false;
                StartCoroutine(CinematicMouvement());
            }
            else
            {
                
                isEnded = true;
                return;
            }
        }

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
            print(distance);
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
