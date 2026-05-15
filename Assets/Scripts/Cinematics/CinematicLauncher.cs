using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CinematicLauncher : MonoBehaviour
{
    // Liste des éléments de la cinématique (dialogues, mouvements, etc.)
    [SerializeField]
    private List<CinematicElement> cinematicElements;

    // Si vrai, la cinématique se lance automatiquement au Start
    [SerializeField]
    private bool launchOnStart;

    // Si vrai, le joueur garde le contrôle pendant la cinématique
    [SerializeField]
    private bool controlPlayer;

    // Si faux, le launcher se détruit à la fin de la cinématique
    [SerializeField]
    private bool dontDestroy;

    // Si vrai, l'UI de cinématique ne se ferme pas à la fin
    [SerializeField]
    private bool DontEndUI;

    // Référence potentielle à un objet d'interaction lié au chargement de scène
    private Interactable interactable;

    // Référence au système de pause
    public PauseSystem pause;

    // Paramètre envoyé au manager pour savoir si on rend le contrôle au joueur à la fin
    [SerializeField]
    private bool EndPlayer;

    // Dit si cette cinématique a été skippée
    public bool isSkipped;

    // Copie publique de isSkipped, probablement lue ailleurs
    public bool Skip;

    // Empêche ce launcher de relancer sa cinématique plusieurs fois
    private bool isCinematicLaunched;

    void Start()
    {
        // Si un interactable est lié à ce launcher
        if (interactable != null)
        {
            // Et si on vient d'un chargement déclenché par lui
            if (interactable.LoadIsComingFromMe)
            {
                // Alors on décide si la cinématique doit se lancer au Start ou non
                launchOnStart = !interactable.dontStartCinematicOnStart;
            }
        }

        // Récupère tous les CinematicElement enfants de cet objet
        cinematicElements = transform.GetComponentsInChildren<CinematicElement>().ToList();

        // Si ce launcher doit lancer la cinématique automatiquement
        if (launchOnStart)
        {
            // On s'enregistre comme launcher courant dans le manager
            CinematicManager.Instance.cinematicLauncher = this;

            // On demande au manager de démarrer la cinématique
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);

            // Debug console
            print("LaunchOnStart");
        }

        // Récupère la référence au système de pause, même si l'objet est inactif
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);
    }

    public void Launch()
    {
        // Lance la cinématique manuellement depuis un autre script
        CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);

        // Debug console
        print("Launch on Launch!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le jeu est en pause, on ne lance rien
        if (pause.isPaused)
        {
            return;
        }

        // Si cette cinématique a déjà été lancée par ce launcher, on stoppe
        if (isCinematicLaunched) return;

        // Si c'est bien le joueur qui entre dans le trigger
        if (collision.CompareTag("Player"))
        {
            // On marque ce launcher comme déjà utilisé
            isCinematicLaunched = true;

            // Si le manager référence déjà ce launcher, inutile de relancer
            if (CinematicManager.Instance.cinematicLauncher == this) return;

            // On définit ce launcher comme launcher courant
            CinematicManager.Instance.cinematicLauncher = this;

            // On démarre la cinématique correspondante
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);

            // Debug console
            print("Launch on COllision!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    void Update()
    {
        // Si le joueur appuie sur P et que la cinématique n'a pas encore été skippée
        if (Input.GetKeyDown(KeyCode.P) && !isSkipped)
        {
            // On marque la cinématique comme skippée
            isSkipped = true;

            // Ancienne tentative : retirer les éléments déjà terminés de la liste
            // cinematicElements.RemoveAll(element => element.IsEnded());

            // On demande au manager de terminer la cinématique
            CinematicManager.Instance.EndCinematic();

            // Debug console
            Debug.Log("Cinematic Skipped Succesfully !");
        }

        // On synchronise la variable publique Skip avec l'état réel
        Skip = isSkipped;
    }

    public void CinematicEnded()
    {
        // Le launcher redevient disponible pour un futur lancement
        isCinematicLaunched = false;

        // Si le manager pointe encore vers ce launcher,
        // on nettoie sa référence
        if (CinematicManager.Instance.cinematicLauncher == this)
        {
            CinematicManager.Instance.cinematicLauncher = null;
        }

        // Debug console
        print("Cinematic Ended");

        // Si ce launcher n'est pas censé survivre après usage, on le détruit
        if (!dontDestroy)
        {
            Destroy(gameObject);
        }
    }
}