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
    
    public static CinematicManager Instance;
    public CinematicLauncher CinematicLauncher;
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
        CinematicLauncher.CinematicEnded();

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


        for (int i = 0; i < cinematicElements.Count; i++)
        {
            CinematicElement element = cinematicElements[i];
            if (i != 0 && cinematicElements[i-1] is CE_Text && cinematicElements[i] is CE_Text)
            {
                var elementTemp = cinematicElements[i-1]  as CE_Text;
                var CurrentElementTemp = cinematicElements[i]  as CE_Text;
                if (elementTemp.deniedCrew == CurrentElementTemp.deniedCrew)
                {
                    CinematicUI  = true;
                    element.StartProcess();
            
                    yield return new WaitUntil(()=>NextCinematicElement(element));
                }
                else
                {
                    CinematicUI = false;
                    element.StartProcess();
            
                    yield return new WaitUntil(()=>NextCinematicElement(element));
                }
                
            }
            else
            {
                CinematicUI = false;
                element.StartProcess();
            
                yield return new WaitUntil(()=>NextCinematicElement(element));
            }

        }

        player.CinematicPlaying = false;
        CinematicUI = false;
        CinematicLauncher.CinematicEnded();
    }



}
