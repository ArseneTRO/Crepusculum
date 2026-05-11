
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public loadScreen loadScene;
    bool isFromAnotherScene;
    GameObject AnotherChangeScene;
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

        loadScene = FindFirstObjectByType<loadScreen>();
    }
    public void ChangeTheScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string theSceneName)
        { 
            loadScene.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(theSceneName);
            yield return new WaitForSeconds(0.5f);
            loadScene.gameObject.SetActive(false);
            isFromAnotherScene = true;
            yield break;
        }
}
