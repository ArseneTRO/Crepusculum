using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;


public class CinematicManager : MonoBehaviour
{


    //Singleton (porte d'entrée pour accéder à chaque élément facilement) (absolument exceptionnel)

    public static CinematicManager Instance;
    public bool CinematicUI;
    public Animator animator;

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
        if (CinematicUI && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextStep();
        }

        animator.SetBool("CinematicIsOn", CinematicUI);
    }


    public TMP_Text dialogueText;
    public PlayerMovement player;
    [System.Serializable]
    public class Cinematic   // Relatif à sois meme
    {
        public Sprite sprite;
        public string[] sentences;
        public Vector2 positionStart;
        public Vector2 positionEnd;
        public StepType stepType;
        public GameObject target;
        public float moveSpeed;
        public float zoomStart;
        public float zoomEnd;
        public CinemachineCamera myCamera;
        public float cameraSpeed;
    }
    public enum StepType
    {
        Text,
        Movement,
        FadeOut,
        FadeIn
    }
    Queue<Cinematic> CinematicQueue = new Queue<Cinematic>();
   
    public void DisplayNextStep()
    {
        if (CinematicQueue.Count == 0)
        {
            EndCinematic();
            return;
        }
        StopAllCoroutines();

        Cinematic cinematicStep = CinematicQueue.Dequeue();
        switch (cinematicStep.stepType)
        {
            case StepType.Text:
                StartCoroutine(TypeSentence(cinematicStep.sentences[0]));
                break;
            case StepType.Movement:
                StartCoroutine(CinematicMouvement(cinematicStep));
                break;
            case StepType.FadeOut:
                // Code pour gérer le fade out
                break;
            case StepType.FadeIn:
                // Code pour gérer le fade in
                break;
        }
        StartCoroutine(Cameraman(cinematicStep));


    }

    public void EndCinematic()
    {
        player.CinematicPlaying = false;
        CinematicUI = false;

    }

    IEnumerator TypeSentence(string CinematicSentence)
    {
        dialogueText.text = "";
        foreach (char letter in CinematicSentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public void StartCinematic(List<Cinematic> cinematicSteps, bool controlPlayer)
    {
        
        if (controlPlayer)
        {
            player.CinematicPlaying = true;
        }

        foreach (Cinematic step in cinematicSteps)
        {
            CinematicQueue.Enqueue(step);
        }
        CinematicUI = true;
        DisplayNextStep();
    }




    IEnumerator CinematicMouvement(Cinematic cinematicStep)
    {
        
        Rigidbody2D targetRb = cinematicStep.target.GetComponent<Rigidbody2D>();
        float distance = Vector2.Distance(cinematicStep.positionEnd, cinematicStep.positionStart);
        while (distance > 0.3f)
        {
            Vector2 dirToTarget = (cinematicStep.positionEnd - (Vector2)cinematicStep.target.transform.position).normalized;
            targetRb.linearVelocity = dirToTarget * cinematicStep.moveSpeed;
            distance = Vector2.Distance(cinematicStep.positionEnd, cinematicStep.target.transform.position);
            yield return null;
        }
            targetRb.linearVelocity = Vector2.zero;
        DisplayNextStep();
        yield break;
    }

    IEnumerator Cameraman(Cinematic cinematicStep)
    {
        float t = 0f;
        while (t < 1f)
        {
            cinematicStep.myCamera.Lens.OrthographicSize = Mathf.Lerp(cinematicStep.zoomStart, cinematicStep.zoomEnd, t);
            t += Time.deltaTime / cinematicStep.cameraSpeed;
            yield return null;
        }


        yield break;
    }


}


