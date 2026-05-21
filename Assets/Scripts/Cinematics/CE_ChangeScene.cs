
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

//Demande un changement de scène, déclenche le ChangeScene

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




