
using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.SceneManagement;
using UnityEditor;

    public class CE_ChangeScene : CinematicElement
    {
        public bool WeNeedToLoadScene = false;
        public string sceneName;
        public bool isEnded;
        public ChangeScene changeScene;
    public override void PostStartProcess()
        {
            {
            if (WeNeedToLoadScene)
                {
                changeScene = FindFirstObjectByType<ChangeScene>();
                changeScene.ChangeTheScene(sceneName);
                }
            }
        }
        public override bool IsEnded()
        {
            return isEnded;
        }
        
    }




