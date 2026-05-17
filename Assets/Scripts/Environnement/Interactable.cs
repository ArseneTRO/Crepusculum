using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D range;
    [SerializeField]
    private FlowerSystem FlowerSystem;
    private bool isInRange;
    [SerializeField]
    private string myScene;
    [SerializeField]
    private GameObject shortLoading;
    [SerializeField]
    private GameObject Feedback;
    [SerializeField]
    private bool instructions;
    [SerializeField]    
    private bool Verify;
    
    public string ItemSearched;
    public int AmountRequired;
    public Verifier Verifier;
    public CinematicLauncher Accepted;
    public CinematicLauncher Denied;
    [SerializeField]
    private bool noCinematicOnStart;
    [HideInInspector]
    public bool dontStartCinematicOnStart;
    [SerializeField]
    private Vector2 position;
    [SerializeField]
    private Transform playerTransform;
    [HideInInspector]
    public bool LoadIsComingFromMe;
    public PauseSystem pause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        DontDestroyOnLoad(shortLoading);
        DontDestroyOnLoad(Feedback);
        DontDestroyOnLoad(Feedback.gameObject);
    }
    void Start()
    {
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.isPaused)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            StartCoroutine(Enter());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FlowerSystem.interactable != this.gameObject)
                {
                    FlowerSystem.interactable = this.gameObject;
                    isInRange=true;
                }
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

    IEnumerator Enter()
    {
        if (Verifier)
        {
            Verifier.CheckSomething(ItemSearched, AmountRequired, Accepted, Denied);
            yield return null;
        }
        else
        {
            shortLoading.SetActive(true);
            LoadIsComingFromMe = true;
            if (instructions)
            {
                if(noCinematicOnStart)
                {
                    dontStartCinematicOnStart = true;
                }
                SceneManager.LoadScene(myScene);
                playerTransform.position = position;
                yield return new WaitForSeconds(1);
                shortLoading.SetActive(false);
                LoadIsComingFromMe = false;
                dontStartCinematicOnStart=false;
                yield break;
            }
            SceneManager.LoadScene(myScene);
            yield return new WaitForSeconds(1);
            shortLoading.SetActive(false);
        }
    }

}

