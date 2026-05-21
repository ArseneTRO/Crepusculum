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

    //Système pour le runner du niveau 4 qui prévois le déplacement, et la mort du joueur  s'il est distancé de 12 unités par Azraët
    void Update()
    {


        {
            
        }
        if (IsRunnerWorking)
        {
            rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y);
        }
        var dist = Mathf.Abs(playerTransform.position.x - AzraetTransform.position.x);
        if (dist > 12)
        {
            playerHP.Die();
        }
    }


}
