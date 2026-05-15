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
    [SerializeField]
    private bool dontDestroy;
    [SerializeField]
    private bool DontEndUI;
    private Interactable interactable;
    public PauseSystem pause;
    [SerializeField]
    private bool EndPlayer;
    public bool isSkipped;
    public bool Skip;
    private bool isCinematicLaunched;

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
            CinematicManager.Instance.cinematicLauncher = this;
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
            print("LaunchOnStart");
        }
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);

    }

    public void Launch()
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
            print("Launch on Launch!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

private void OnTriggerEnter2D(Collider2D collision)
{
        if (pause.isPaused)
        {
            return;
        }
        if (isCinematicLaunched) return;
        if (collision.CompareTag("Player"))
        {
            isCinematicLaunched = true;
            if (CinematicManager.Instance.cinematicLauncher == this) return;
            CinematicManager.Instance.cinematicLauncher = this;
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
            print("Launch on COllision!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isSkipped) 
        {
            isSkipped = true;
            //cinematicElements.RemoveAll(element => element.IsEnded());
            CinematicManager.Instance.EndCinematic();
            Debug.Log("Cinematic Skipped Succesfully !");
        }
        Skip = isSkipped;
    }

    

    public void CinematicEnded()

    {
        isCinematicLaunched = false;
        if (CinematicManager.Instance.cinematicLauncher == this)
        {
            CinematicManager.Instance.cinematicLauncher = null;
        }
        print("Cinematic Ended");
        if (!dontDestroy)
        {
            Destroy(gameObject);
        }
    }
}
