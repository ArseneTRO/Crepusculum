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

    //Discovering Système, s'active seul lorsqu'on découvre quelque chose, comme les fleurs ou un nouveau chemin
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
