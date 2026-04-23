
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
    public CE_CheckSomething check;
    public bool deniedCrew = false;
    private bool myDenied;

    public override void PostStartProcess()
    {
        check =  FindFirstObjectByType<CE_CheckSomething>();
        if (check == null)
        {
            myDenied = false;
        }
        myDenied = check.isDenied;
        if (!check.iDidMyRole)
        {
            myDenied = false;
        }
        if (deniedCrew)
        {
            if (myDenied)
            {
                if (WeNeedToLoadScene)
                {
                changeScene = FindFirstObjectByType<ChangeScene>();
                changeScene.ChangeTheScene(sceneName);
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            if (!myDenied)
            {
                if (WeNeedToLoadScene)
                {
                changeScene = FindFirstObjectByType<ChangeScene>();
                changeScene.ChangeTheScene(sceneName);
                }
            }
            else
            {
                return;
            }
        }
            
        
    }
        public override bool IsEnded()
        {
            return isEnded;
        }
        
    }




