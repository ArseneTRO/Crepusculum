
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Canvas loadScene;
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

        loadScene = GameObject.Find("LoadScreen")?.GetComponent<Canvas>();
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

    void Update()
    {
        if(loadScene == null)
        {
            loadScene = GameObject.Find("LoadScreen")?.GetComponent<Canvas>();
        }
    }

    IEnumerator LoadScene(string theSceneName)
        { 
            loadScene.scaleFactor = 1.0f;  
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(theSceneName);
            Debug.Log("Load from ChangeScene");
            yield return new WaitForSeconds(0.5f);
            loadScene.scaleFactor = 0;
            isFromAnotherScene = true;
            yield break;
        }
    

}
