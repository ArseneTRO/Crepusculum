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
    //Singleton (porte d'entr�e pour acc�der � chaque �l�ment facilement) (absolument exceptionnel)
    public static CinematicManager Instance;
    public CinematicLauncher CinematicLauncher;
    public bool CinematicUI;
    public Animator animator;
    public bool fromCinematic;
    public TMP_Text dialogueText;
    public PlayerMovement player;
    public PauseSystem pauseSystem;
    private bool GiveBackControl;

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
        if (!GiveBackControl)
        {
            player.CinematicPlaying = false;
            //safe
        }
        CinematicUI = false;
        CinematicLauncher.CinematicEnded();

    }

    private bool NextCinematicElement(CinematicElement element)
    {
        return element.IsEnded();
    }

    public void StartCinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI, bool EndPlayer)
    {
        StartCoroutine(Cinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer));
    }

    private IEnumerator Cinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI, bool EndPlayer)
    {
        
        if (!controlPlayer)
        {
            player.CinematicPlaying = true;
            GiveBackControl = EndPlayer;
        }

        


        foreach (CinematicElement element in cinematicElements)
        {
            CinematicUI = false;
            element.StartProcess();
            
            yield return new WaitUntil(()=>NextCinematicElement(element));

        }

        if (GiveBackControl)
        {
            player.CinematicPlaying = false;
            print("C'est moi le fouteur de merde");
        }
        if (!DontEndUI)
        {
            CinematicUI = false;
        }
        CinematicLauncher.CinematicEnded();
    }



}
