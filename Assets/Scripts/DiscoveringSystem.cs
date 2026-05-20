using UnityEngine;
using UnityEngine.UI;

public class DiscoveringSystem : MonoBehaviour
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private string[] Description;
    [SerializeField]
    private Sprite Illustration;


    private void OnTriggerEnter2D(Collider2D collision)
    {

     if (DiscoverManager.Instance.discoveredItems.Contains(Name))
     {
       return;
     }
     
     
        DiscoverManager.Instance.discoveredItems.Add(Name);
        DialogueManager.Instance.StartDialogue(new Dialogue { name = Name, sentences = Description, sprite = Illustration}, true);
    
    
    }
}
