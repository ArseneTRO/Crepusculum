using UnityEngine;
using System.Collections;

public class CE_TriggerBis : CinematicElement
{
    [SerializeField]
    public RunnerSystem runner;
    public bool isEnded;
    [SerializeField]
    private float StartDelay;
    [SerializeField]
    private bool _state;

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
        Debug.Log("Runner begin !");
        isEnded = false;
        yield return new WaitForSeconds(0.5f);
        runner.IsRunnerWorking = _state;
        Debug.Log("Runner end !");
        isEnded = true;
        yield break;
    }
}
