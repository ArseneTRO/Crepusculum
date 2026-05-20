using UnityEngine;

public class loadScreen : MonoBehaviour
{
    public ChangeScene changeScene;

    public static loadScreen Instance;
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
        if (changeScene != null)
        {
            changeScene.loadScene = this.gameObject;
        }
    }

    void Update()
    {
        
    }
}
