using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public bool Skip;
    [SerializeField]
    private string cinematicID;
    public PlayerMovement player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
        if(string.IsNullOrEmpty(cinematicID))
        {
            cinematicID = this.gameObject.name + SceneManager.GetActiveScene().name;
        }
        if (interactable != null)
            {
                if (interactable.LoadIsComingFromMe) 

                    {
                        launchOnStart = !interactable.dontStartCinematicOnStart;
                    }
            }
        

        cinematicElements = transform.GetComponentsInChildren<CinematicElement>().ToList();  
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);

        if(launchOnStart)
        {
            if(SceneManager.GetActiveScene().name != "Level4")
            {
                if(PlayerPrefs.GetInt(cinematicID, 0) == 0)
                {
                    CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
                    CinematicManager.Instance.CinematicLauncher = this;
                    Skip = false;
                }
                else
                {
                    player.CinematicPlaying = false;
                    return;
                }
            }

        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
            CinematicManager.Instance.CinematicLauncher = this;
            Skip = false;
        }

        }
    }

    public void Launch()
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
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
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer, DontEndUI, EndPlayer);
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Skip = true; 
        }
    }

    

    public void CinematicEnded()
    {
        Skip = false;
        PlayerPrefs.SetInt(cinematicID, 1);
        if (CinematicManager.Instance.CinematicLauncher == this)
        {
            CinematicManager.Instance.CinematicLauncher = null;
        }
        print("Cinematic Ended");
        if (!dontDestroy)
        {
            Destroy(gameObject);
        }
    }
}
