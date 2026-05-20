
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject loadScene;
    bool isFromAnotherScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ChangeScene Instance;
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject); // doublon
        }

    }

    void Start()
    {
        loadScene.SetActive(false);
    }
    public void ChangeTheScene(string sceneName)
    {
        if (loadScene != null)
        {
            StartCoroutine(LoadScene(sceneName));
        }
        else
        {
            Debug.Log("Pas de loadscreen !");
        }
    }

    IEnumerator LoadScene(string theSceneName)
        { 
            loadScene.SetActive(true);
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(theSceneName);
            Debug.Log("Load from ChangeScene");
            yield return new WaitForSeconds(0.5f);
            loadScene.gameObject.SetActive(false);
            isFromAnotherScene = true;
            yield break;
        }
    

}
