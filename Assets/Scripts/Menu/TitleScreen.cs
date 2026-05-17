using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

using UnityEngine.UI;
using NUnit.Framework;

public class TitleScreen : MonoBehaviour
{
    public GameObject Options;
    public Image randomSprite;
    public List<Sprite> sprites;
    public int result;
    public Animator PlayScreenAnimation;
    [SerializeField]
    private GameObject PlayScreen;
    public SaveData save;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Options.SetActive(false);
        save = FindFirstObjectByType<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        save.iAlreadyPlaceThePlayer = false;
        SceneManager.LoadScene(PlayerPrefs.GetString("LevelName", "SnowScene"));
    }

    public void Quit()
        {
                Application.Quit();
        }

    public void Option()
    {
        Options.SetActive(true);
        result = UnityEngine.Random.Range(0, 100);
        if (result >= 50)
        {
            randomSprite.sprite = sprites[0];
        }
        else if (result >= 20)
        {
            randomSprite.sprite = sprites[1];
        }
        else if (result >1)
        {
            randomSprite.sprite = sprites[2];
        }
        else
        {
            randomSprite.sprite = sprites[3];
        }


    }
    public void Resume()
    {
        Options.SetActive(false);
    }

    public void OpenPlay()
    {
        PlayScreenAnimation.SetBool("PlayScreenIsOpening", true);
    }
    public void ClosePlay()
    {
        PlayScreenAnimation.SetBool("PlayScreenIsOpening", false);
    }
        public void PlayFromBegenning()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SnowScene");
    }



}
