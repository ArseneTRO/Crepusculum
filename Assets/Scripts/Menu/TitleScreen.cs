using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject Options;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("SnowScene");
    }

    public void Quit()
        {
            Application.Quit();
    }

    public void Option()
    {
        Options.SetActive(true);
    }
    public void Resume()
    {
        Options.SetActive(false);
    }


}
