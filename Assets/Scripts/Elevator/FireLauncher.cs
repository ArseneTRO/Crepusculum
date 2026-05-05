using UnityEngine;
using System.Collections;

public class FireLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject Fire1;
    [SerializeField]
    private Animator Fire1Anim;
    [SerializeField]
    private GameObject Fire2;
    [SerializeField]
    private Animator Fire2Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Fire());
        Fire1Anim.SetBool("LauncheFire", true);
        Fire1Anim.SetBool("StopFire", false);
        Fire2Anim.SetBool("LauncheFire", false);
        Fire2Anim.SetBool("StopFire", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        Fire1.SetActive(false);
        Fire2.SetActive(true);
        Fire2Anim.SetBool("StopFire", false);
        Fire2Anim.SetBool("LaunchFire", true);
        yield return new WaitForSeconds(3);
        Fire2Anim.SetBool("LaunchFire", false);
        Fire2Anim.SetBool("StopFire", true);
        yield return new WaitForSeconds(1f);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Fire1.SetActive(true);
        Fire2.SetActive(false);
        Fire1Anim.SetBool("LaunchFire", true);
        Fire1Anim.SetBool("StopFire", false);
        yield return new WaitForSeconds(3);
        Fire1Anim.SetBool("LaunchFire", false);
        Fire1Anim.SetBool("StopFire", true);
        yield return new WaitForSeconds(1f);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Fire());
        yield break;
    }
}
