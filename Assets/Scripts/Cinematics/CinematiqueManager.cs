using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Serialization;


public class CinematicManager : MonoBehaviour
{
    // Singleton : une seule instance accessible partout via CinematicManager.Instance
    public static CinematicManager Instance;
    [FormerlySerializedAs("CinematicLauncher")] public CinematicLauncher cinematicLauncher; // Le launcher qui a déclenché la cinématique en cours
    [FormerlySerializedAs("CinematicUI")] public bool cinematicUI;                    // True = l'UI de cinématique est affichée
    public Animator animator;                   // Animator qui gère l'apparition/disparition de l'UI
    public bool fromCinematic;                  // Indique si on vient d'une cinématique (utilisé ailleurs)
    public TMP_Text dialogueText;               // Référence au texte de dialogue affiché à l'écran
    public PlayerMovement player;               // Référence au script de mouvement du joueur
    public PauseSystem pauseSystem;             // Référence au système de pause
    private bool GiveBackControl;               // Si true, on ne redonne PAS le contrôle au joueur à la fin

    private void Awake()
    {
        // Singleton : si aucune instance n'existe, on devient l'instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Si une instance existe déjà (doublon), on se détruit
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
        // Met à jour l'animator en permanence selon l'état de l'UI cinématique
        animator.SetBool("CinematicIsOn", cinematicUI);
    }

    public void EndCinematic()
    {
        // Si GiveBackControl est false, on redonne le contrôle au joueur
        if (!GiveBackControl)
        {
            player.CinematicPlaying = false;
        }
        cinematicUI = false;
        // Prévient le launcher que la cinématique est terminée
        cinematicLauncher.CinematicEnded();
    }

    // Condition utilisée par WaitUntil : attend que l'élément soit terminé
    private bool NextCinematicElement(CinematicElement element)
    {
        return element.IsEnded();
    }

    public void StartCinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI, bool EndPlayer)
    {
        GiveBackControl = EndPlayer;
        cinematicLauncher.isSkipped = false;
        // Lance la coroutine qui joue les éléments un par un
        StartCoroutine(Cinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer));
    }

    private IEnumerator Cinematic(List<CinematicElement> cinematicElements, bool controlPlayer, bool DontEndUI, bool EndPlayer)
    {
        var myLauncher = cinematicLauncher;
        GiveBackControl = EndPlayer;

        // Si controlPlayer est false, on bloque le joueur pendant la cinématique
        if (!controlPlayer)
        {
            player.CinematicPlaying = true;
        }

        // On joue chaque élément de la cinématique dans l'ordre
        foreach (CinematicElement element in cinematicElements)
        {
            cinematicUI = false;
            element.StartProcess(); // Démarre l'élément (dialogue, mouvement, tp...)
            yield return new WaitUntil(() => NextCinematicElement(element) || (myLauncher?.Skip ?? false));

            if (myLauncher?.Skip ?? false)
            {
                break;
            }
            
            // ⚠️ PROBLÈME ICI : on attend que l'élément soit fini avant de passer au suivant
            // Mais si on skip (EndCinematic), la coroutine continue quand même à tourner
            // et va exécuter les éléments suivants malgré le skip
        }

        // Redonne le contrôle si nécessaire
        if (!GiveBackControl)
        {
            player.CinematicPlaying = false;
        }
        if (!DontEndUI)
        {
            cinematicUI = false;
        }
        myLauncher.isSkipped = false;
        myLauncher.CinematicEnded();
    }
}