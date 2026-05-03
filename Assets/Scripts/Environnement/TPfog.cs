using UnityEngine;

public class TPfog : MonoBehaviour
{
    public GameObject Me;
    public GameObject TP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Me = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
            collision.gameObject.GetComponent<Transform>().position = new Vector3(TP.GetComponent<Transform>().position.x, collision.gameObject.GetComponent<Transform>().position.y, 0);
            print("J'ai TP");

    }
}
