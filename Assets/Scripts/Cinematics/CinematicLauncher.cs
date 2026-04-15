using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CinematicLauncher : MonoBehaviour
{

    [SerializeField]
    private List<CinematicElement> cinematicElements;
    [SerializeField]
    private bool launchOnStart;
    [SerializeField]
    private bool controlPlayer;
    private Interactable interactable;
    public PauseSystem pause;

    void Start()
    {
        if (interactable != null)
            {
                if (interactable.LoadIsComingFromMe) 

                    {
                        launchOnStart = !interactable.dontStartCinematicOnStart;
                    }
            }
        

        cinematicElements = transform.GetComponentsInChildren<CinematicElement>().ToList();  

        if(launchOnStart)
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
        }
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pause.isPaused)
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            if (CinematicManager.Instance.CinematicLauncher == this) return;
            CinematicManager.Instance.CinematicLauncher = this;
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            cinematicElements.RemoveAll(element => element.IsEnded());
            CinematicManager.Instance.EndCinematic();
        }
    }

    

    public void CinematicEnded()
    {
        if (CinematicManager.Instance.CinematicLauncher == this)
        {
            CinematicManager.Instance.CinematicLauncher = null;
        }
        print("Cinematic Ended");
        Destroy(gameObject);
    }
}
