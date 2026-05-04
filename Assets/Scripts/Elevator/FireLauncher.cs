using UnityEngine;
using System.Collections;

public class FireLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject Fire1;
    [SerializeField]
    private GameObject Fire2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        Fire1.SetActive(false);
        Fire2.SetActive(true);
        yield return new WaitForSeconds(3);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Fire1.SetActive(true);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(3);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Fire());
        yield break;
    }
}
