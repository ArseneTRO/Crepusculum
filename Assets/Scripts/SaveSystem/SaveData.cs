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
    public bool isLevel4;

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
        if(SceneManager.GetActiveScene().name == "Level4")
        {
            isLevel4 = true;
            Destroy(this.gameObject);
        }
        else
        {
            isLevel4 = false;
        }
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
        if (!isLevel4)
        {
         PlayerPrefs.SetFloat("PositionX", player.gameObject.transform.position.x);
         PlayerPrefs.SetFloat("PositionY", player.gameObject.transform.position.y);
         PlayerPrefs.SetString("LevelName", SceneManager.GetActiveScene().name);
         PlayerPrefs.Save();
        }
        else if (isLevel4)
        {
         PlayerPrefs.SetFloat("PositionX", 45.41f);
         PlayerPrefs.SetFloat("PositionY", -0.87f);
         PlayerPrefs.SetString("LevelName", "Level3");
         print("Level 4 detected !!!");
        }


    }

    public void LoadData()
    {
        if (!gameIsLaunched && !isLevel4)
        {
            gameIsLaunched = true;
            SceneManager.LoadScene(PlayerPrefs.GetString("LevelName", "SnowScene"));
            player.transform.position = new Vector2(-16, 0);
            Debug.Log("Load from SaveData");
            
            Debug.Log("Load Data lancé");
        }
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = FindFirstObjectByType<FlowerSystem>();
        if (!iAlreadyPlaceThePlayer && player != null)
        {
            iAlreadyPlaceThePlayer = true;
            player.gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("PositionX", 0), PlayerPrefs.GetFloat("PositionY", 0));
        }
        Debug.Log("OnSceneLoaded lancé");
    }
}
