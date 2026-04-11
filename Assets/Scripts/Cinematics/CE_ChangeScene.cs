using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CE_ChangeScene : CinematicElement
{

    public bool WeNeedToLoadScene = false;
    public GameObject loadScene;
    public string sceneName;
    public bool isEnded;

    void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    public override void PostStartProcess()
    {
        {
            StartCoroutine(LoadScene());
            Destroy(gameObject);
        }
    }
    public override bool IsEnded()
    {
        return isEnded;
    }
        IEnumerator LoadScene()
            {
                if (WeNeedToLoadScene)
                {   
                    loadScene.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    SceneManager.LoadScene(sceneName);
                    yield return new WaitForSeconds(4f);
                    loadScene.gameObject.SetActive(false);
                    isEnded = true;
                    yield break;
                }
            }

}

