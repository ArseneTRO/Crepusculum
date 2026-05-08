using UnityEngine;

public class RunnerSystem : MonoBehaviour
{
    public bool IsRunnerWorking;
    public GameObject RunnerObject;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunnerWorking)
        {
            rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y);
            print("Position modifiée");
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y);
            print("Rigibody EGALE ZEROOOOOOOOO");
        }

    }


}
