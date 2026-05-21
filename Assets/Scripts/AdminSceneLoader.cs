using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _scene;
    //Ce script est utile pour le title screen, il permet juste de faire le petit panneau admin pour sélectionner directement un niveau pour les tests

    public void loadScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(_scene);
        return;
    }
}
