using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using static CinematicManager;

//CinematicManager définit le déroulement d'un cinématique. Il est le schéma type de celle-ci, le mode d'emplois si on préfère
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
    [SerializeField]
    private bool GiveBackControl;
    public DialogueManager DialogueManager;
    private bool _skip;


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
        DialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    private void Update()
    {
        animator.SetBool("CinematicIsOn", CinematicUI);
        
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            _skip = true; 
            
            animator.SetBool("CinematicIsOn", false);
        }
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
        if (_skip)
        {
            CinematicUI = false;
            DialogueManager.EndDialogue();
            print("Skip partiel");
            if (element.GetType() == typeof(CE_Dialogue) || element.GetType() == typeof(CE_Text))
            {
                print("Skip total");
                return true;
            }
            
        }
        print("no skip");
        return element.IsEnded();
    }

        public void StartCinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI, bool EndPlayer)
        {
            _skip = false;
            GiveBackControl = EndPlayer;
            StartCoroutine(Cinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer));
        }

        private IEnumerator Cinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI,
            bool EndPlayer)
        {
            GiveBackControl = EndPlayer;
            if (!controlPlayer)
            {
                player.CinematicPlaying = true;
            }




            foreach (CinematicElement element in cinematicElements)
            {
                CinematicUI = false;
                element.StartProcess();

                yield return new WaitUntil(() => NextCinematicElement(element));

            }

            if (!GiveBackControl)
            {
                player.CinematicPlaying = false;

            }

            if (!DontEndUI)
            {
                CinematicUI = false;
            }

            CinematicLauncher.CinematicEnded();
        }



}

