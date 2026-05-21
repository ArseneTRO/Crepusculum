using UnityEngine;
using System.Collections;



public class CE_TP : CinematicElement
{
    
    public Vector3 tpPosition;
    public GameObject target;
    public bool isEnded;
    [SerializeField]
    private Transform targetTransform;

    //Tp la target à une position
    public override void PostStartProcess()
    {
        isEnded = false;
        StartCoroutine(Teleportation());
    }
    IEnumerator Teleportation()
    {
        targetTransform = target.GetComponent<Transform>();
        targetTransform.position = tpPosition;
        while (targetTransform.position != tpPosition)
        {
            yield return new WaitForEndOfFrame();
        }
        isEnded = true;
        yield break;
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
