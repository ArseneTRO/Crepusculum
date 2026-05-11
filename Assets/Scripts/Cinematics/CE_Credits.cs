using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CE_Credits : CinematicElement
{
    public Animator AllCredits;
    public bool isEnded;
    private bool CreditsOn;

    public override void PostStartProcess()
    {
        StartCoroutine(StartCredits());
    }

    IEnumerator StartCredits()
    {
        
        yield return new WaitForSeconds(2);
        AllCredits.SetBool("Credits", true);
        yield return new WaitForSeconds(10);
        CreditsOn = true; 
        yield return new WaitForSeconds(52);
    }

    private void Update()
    {
        if (CreditsOn && Input.GetKey(KeyCode.Space))
        {
            CreditsOn = false;
            isEnded = true;
            SceneManager.LoadScene("TitleScreen");
        }
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
