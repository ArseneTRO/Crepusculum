using UnityEngine;
using System.Collections;

public class TempPlateform : MonoBehaviour
{
    [SerializeField]
    private GameObject Me;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        Me.SetActive(false);
        yield return new WaitForSeconds(5);
        Me.SetActive(true);
        yield break;
    }
}
