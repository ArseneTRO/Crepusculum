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


}
