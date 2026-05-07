using UnityEngine;
using System.Collections;

public class TempPlateform : MonoBehaviour
{
    [SerializeField]
    private GameObject Me;
    [SerializeField]
    private float timeBeforeDisappear;
    [SerializeField]
    private float timeBeforeAppear;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeBeforeDisappear);
        Me.SetActive(false);
        yield return new WaitForSeconds(timeBeforeAppear);
        Me.SetActive(true);
        yield break;
    }
}
