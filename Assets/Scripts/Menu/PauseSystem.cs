using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{

    private bool pause;
    public bool isPaused;
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject OptionsScreen;


    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = pause;
        if (!isPaused)
        {
            pauseScreen.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pause = true;
            pauseScreen.SetActive(true);
        }        
        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            pause = true;
            pauseScreen.SetActive(true);
        }
    }

        public void OptionEnter()
        {
            OptionsScreen.SetActive(true);
        }
        public void OptionExit()
        {
            OptionsScreen.SetActive(false);
        }
        public void ExitPause()
        {
            pause = false;
            pauseScreen.SetActive(false);
        }
        public void GoToTitleScreen()
        {
            StartCoroutine(GoToTheTitleScreen());
        }
        public void Quit()
        {
            Application.Quit();
        }

        IEnumerator GoToTheTitleScreen()
        {
            pause = false;
            SceneManager.LoadScene("TitleScreen");
            yield return new WaitForSeconds(1f);
            pauseScreen.SetActive(false);
        }




    
}
