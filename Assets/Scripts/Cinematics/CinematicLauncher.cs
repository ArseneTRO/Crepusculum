using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CinematicLauncher : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D range;
    public GameObject Feedback;
    [SerializeField]
    private FlowerSystem FlowerSystem;
    [SerializeField]
    private bool isInRange;
    [SerializeField]
    private List<CinematicElement> cinematicElements;
    [SerializeField]
    private bool launchOnStart;
    [SerializeField]
    private bool launchOnTriggerEnter;

    [SerializeField]
    private bool controlPlayer;
    private Interactable interactable;
    public PauseSystem pause;

    void Start()
    {
        FlowerSystem = FindFirstObjectByType<FlowerSystem>();
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

        if (pause.isPaused || !launchOnTriggerEnter)
        {
            if (FlowerSystem.interactable != this.gameObject)
                {
                    FlowerSystem.interactable = this.gameObject;
                    isInRange=true;
                }
            return;
        }
        if (collision.CompareTag("Player"))
        {
            if (CinematicManager.Instance.CinematicLauncher == this) return;
            CinematicManager.Instance.CinematicLauncher = this;
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FlowerSystem.interactable == this.gameObject)
            {
                FlowerSystem.interactable = null;
                isInRange=false;
            }
        }
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            cinematicElements.RemoveAll(element => element.IsEnded());
            CinematicManager.Instance.EndCinematic();
        }
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if (CinematicManager.Instance.CinematicLauncher == this) return;
            CinematicManager.Instance.CinematicLauncher = this;
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
        }

        if (isInRange)
        {
            Feedback.SetActive(true);
        }
        else
        {
            Feedback.SetActive(false);
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
