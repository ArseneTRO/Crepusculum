using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI myText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myText.color = Color.lightBlue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        myText.color = Color.white;
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        myText.color = Color.lightBlue;
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
