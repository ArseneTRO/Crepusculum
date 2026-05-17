using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public FlowerSystem player;
    public static SaveData instance;
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
        print(PlayerPrefs.GetFloat("PositionX", player.gameObject.transform.position.x));
        print(PlayerPrefs.GetFloat("PositionY", player.gameObject.transform.position.x));
        print(PlayerPrefs.GetString("LevelName", "SnowScene"));
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
         PlayerPrefs.SetFloat("PositionX", player.gameObject.transform.position.x);
         PlayerPrefs.SetFloat("PositionY", player.gameObject.transform.position.y);
        PlayerPrefs.SetString("LevelName", SceneManager.GetActiveScene().name);
         PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (!gameIsLaunched)
        {
            gameIsLaunched = true;
            SceneManager.LoadScene(PlayerPrefs.GetString("LevelName", "SnowScene"));
            Debug.Log("Load Data lancé");
        }
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = FindFirstObjectByType<FlowerSystem>() ?? null;
        if (!iAlreadyPlaceThePlayer && player != null)
        {
            iAlreadyPlaceThePlayer = true;
            player.gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("PositionX", 0), PlayerPrefs.GetFloat("PositionY", 0));
        }
        Debug.Log("OnSceneLoaded lancé");
    }
}
