using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CinematicElement : MonoBehaviour
{

    public float zoomStart;
    public float zoomEnd;
    public CinemachineCamera myCamera;
    public float cameraSpeed;
    public bool shouldCameraMove;
    

    public void StartProcess()
    {
        if(shouldCameraMove)
        {
            StartCoroutine(Cameraman());
        }
        PostStartProcess();
    }

    public virtual void PostStartProcess()
    {


    }

    public virtual bool IsEnded()
    {
        return true;
    }



    IEnumerator Cameraman()
    {
        float t = 0f;
        while (t < 1f)
        {
            myCamera.Lens.OrthographicSize = Mathf.Lerp(zoomStart, zoomEnd, t);
            t += Time.deltaTime / cameraSpeed;
            yield return null;
        }

        yield break;
    }
}
