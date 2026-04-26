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
    [SerializeField]
    private bool destroyAfterTheEnd;

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
        if (collision.CompareTag("Player"))
        {
            if (pause.isPaused || !launchOnTriggerEnter)
            {
                if (FlowerSystem.interactable != this.gameObject)
                    {
                        FlowerSystem.interactable = this.gameObject;
                        isInRange=true;
                    }
                if (CinematicManager.Instance.CinematicLauncher == this) return;
                CinematicManager.Instance.CinematicLauncher = this;
                return;
            }
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
        Debug.Log("in range : " + isInRange);
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            Debug.Log("E pressé et in range 23: " + isInRange);
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
        if (destroyAfterTheEnd)
        {
        Destroy(gameObject);
        }
    }
}
