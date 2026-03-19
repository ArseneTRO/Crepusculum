using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static CinematicManager;

public class CinematicManager : MonoBehaviour
{
    //Singleton (porte d'entrée pour accéder à chaque élément facilement) (absolument exceptionnel)
    public static CinematicManager Instance;
    public bool CinematicUI;
    public Animator animator;
    public bool fromCinematic;
    public TMP_Text dialogueText;
    public PlayerMovement player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject); // SI  doublon
        }
    }

    private void Update()
    {
        animator.SetBool("CinematicIsOn", CinematicUI);
    }



    public void EndCinematic()
    {
        player.CinematicPlaying = false;
        CinematicUI = false;

    }

    private bool NextCinematicElement(CinematicElement element)
    {
        return element.IsEnded();
    }

    public void StartCinematic(List<CinematicElement> cinematicElements, bool controlPlayer)
    {
        StartCoroutine(Cinematic(cinematicElements, controlPlayer));
    }

    private IEnumerator Cinematic(List<CinematicElement> cinematicElements, bool controlPlayer)
    {
        
        if (!controlPlayer)
        {
            player.CinematicPlaying = true;
        }


        foreach (CinematicElement element in cinematicElements)
        {
            CinematicUI = false;
            element.StartProcess();
            
            yield return new WaitUntil(()=>NextCinematicElement(element));

        }

        player.CinematicPlaying = false;
    }



}
