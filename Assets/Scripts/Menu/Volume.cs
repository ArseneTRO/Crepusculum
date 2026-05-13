using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 1f;
        slider.value = PlayerPrefs.GetFloat("Volume");
        
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
