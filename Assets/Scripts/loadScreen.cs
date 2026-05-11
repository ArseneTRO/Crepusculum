using UnityEngine;

public class loadScreen : MonoBehaviour
{
    public ChangeScene changeScene;
    void Start()
    {
        changeScene = FindFirstObjectByType<ChangeScene>();
        if (changeScene = null)
        {
            changeScene.loadScene = this;
        }
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
