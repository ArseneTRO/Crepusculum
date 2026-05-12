using UnityEngine;

public class loadScreen : MonoBehaviour
{
    public ChangeScene changeScene;
    void Start()
    {
        changeScene = FindFirstObjectByType<ChangeScene>();
        if (changeScene = null)
        {
            changeScene.loadScene = this.GetComponent<Canvas>();
        }

        this.GetComponent<Canvas>().scaleFactor = 0;
    }

    void Update()
    {
        
    }
}
