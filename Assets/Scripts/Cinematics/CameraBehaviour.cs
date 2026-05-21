using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineCamera myCamera;
    public float cameraSpeed;
    public Transform playerTransform;
    public float zoomStart;
    public float zoomEnd;
    [SerializeField]
    private int limitY;
    private bool isCoroutineLaunched;
    [SerializeField]
    private bool Outside;
    //Définit le comportement de la caméra
    void Start()
    {
        isCoroutineLaunched = false;
        Outside = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < limitY && myCamera.Lens.OrthographicSize != zoomEnd && Outside)
        {
            StartCoroutine(CameraIn());
        }
        if (playerTransform.position.y >= limitY && myCamera.Lens.OrthographicSize != zoomStart && !Outside)
        {
            StartCoroutine(CameraOut());
        }
    }

    IEnumerator CameraIn()
    {
        if (isCoroutineLaunched)
        {
            yield break;
        }
        isCoroutineLaunched = true;
        float t = 0f;
        while (t < 1f)
        {
            myCamera.Lens.OrthographicSize = Mathf.Lerp(zoomStart, zoomEnd, t);
            t += Time.deltaTime / cameraSpeed;
            yield return null;
        }
        Outside = false;
        isCoroutineLaunched = false;
        yield break;
    }
    IEnumerator CameraOut()
    {
        if (isCoroutineLaunched)
        {
            yield break;
        }
        isCoroutineLaunched = true;
        float t = 0f;
        while (t < 1f)
        {
            myCamera.Lens.OrthographicSize = Mathf.Lerp(zoomEnd, zoomStart, t);
            t += Time.deltaTime / cameraSpeed;
            yield return null;
        }
        Outside = true;
        isCoroutineLaunched = false;
        yield break;
    }
}
