using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataLevel4 : MonoBehaviour
{
    public FlowerSystem player;
    public static SaveDataLevel4 instance;
    private bool gameIsLaunched;
    public bool iAlreadyPlaceThePlayer;
    public bool saveOnQuit = true;

    public void Start()
    {
        if(SceneManager.GetActiveScene().name != "TitleScreen")
        {
            LoadData();
            saveOnQuit = true;
        }
    }

    private void OnApplicationQuit()
    {
        gameIsLaunched = false;
        iAlreadyPlaceThePlayer = false;
        if(saveOnQuit)
        {
            Save();
        }
    }

    void Update()
    {

    }
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Save()
    {
         PlayerPrefs.SetFloat("PositionX", 45.41f);
         PlayerPrefs.SetFloat("PositionY", -0.87f);
         PlayerPrefs.SetString("Level3", "Level3");
    }


}
