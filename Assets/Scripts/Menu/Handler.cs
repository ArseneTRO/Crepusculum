using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI myText;
    [SerializeField]
    private Color colorBase = Color.white;
    [SerializeField]
    private Color colorHandler = new Color32(0x9E, 0x9E, 0xB7, 0xFF);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myText.color = colorBase;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        myText.color = colorHandler;
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        myText.color = colorBase;
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
