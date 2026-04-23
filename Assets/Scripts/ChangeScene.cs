
using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChangeScene : MonoBehaviour
{
    public GameObject loadScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
            Destroy(this.gameObject);
            yield break;
        }
}
