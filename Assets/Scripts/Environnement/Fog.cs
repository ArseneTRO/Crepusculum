using UnityEngine;

public class Fog : MonoBehaviour
{
    public Transform myTransform;
    public GameObject Object;
    [SerializeField]
    private float speed;
    void Start()
    {
        Object = this.gameObject;
        myTransform = Object.GetComponent<Transform>();
        if(speed == 0)
        {
            speed = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.position = new Vector3(myTransform.position.x - speed * Time.deltaTime, myTransform.position.y, myTransform.position.z);
    }
}
