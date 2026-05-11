using UnityEngine;

public class RunnerSystem : MonoBehaviour
{
    public bool IsRunnerWorking;
    public GameObject RunnerObject;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public Transform playerTransform;
    public Transform AzraetTransform;
    public HealthSystem playerHP;
    public CinematicLauncher Cinematics;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        {
            
        }
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
        var dist = Mathf.Abs(playerTransform.position.x - AzraetTransform.position.x);
        if (dist > 12)
        {
            playerHP.Die();
        }
    }


}
