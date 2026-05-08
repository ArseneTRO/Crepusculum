using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class CE_TriggerBis : CinematicElement
{
    [SerializeField]
    public RunnerSystem runner;
    public bool isEnded;
    [SerializeField]
    private float StartDelay;
    [SerializeField]
    private bool State;

    public override void PostStartProcess()
    {
        StartCoroutine(Trigger());
    }

    public override bool IsEnded()
    {
        return isEnded;
    }

    IEnumerator Trigger()
    {
        Debug.Log("PostStartProcess appelé !");
        isEnded = false;
        yield return new WaitForSeconds(0.5f);
        isEnded = true;
        yield return new WaitForSeconds(StartDelay);
        runner.IsRunnerWorking = State;
        yield break;
    }
}
