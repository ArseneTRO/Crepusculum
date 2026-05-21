using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LulupinMainScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D playerBox;
    [SerializeField]
    private BoxCollider2D myBox;
    [SerializeField]
    private CircleCollider2D playerCircle;
    [SerializeField]
    private CircleCollider2D myCircle;
    [SerializeField]
    private Transform vitalinaTransform;

    private Joint2D myJoint;
    [SerializeField]
    private Transform myTransform;
    public bool distanceSystem;
    public PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }
    
    void Update()  
    {
        myJoint = this.gameObject.GetComponent<Joint2D>();
        Physics2D.IgnoreCollision(playerBox, myBox);
        Physics2D.IgnoreCollision(playerCircle, myCircle);
        Physics2D.IgnoreCollision(playerCircle, myBox);
        Physics2D.IgnoreCollision(playerBox, myCircle);
        float distance = Vector3.Distance(vitalinaTransform.position, myTransform.position);

        if(distanceSystem && SceneManager.GetActiveScene().name != "SnowScene")
        { 
            if (distance > 1.5)
            {
                // Retour à la base en priorité
                myTransform.position = vitalinaTransform.position;
            }
        }

        if (playerMovement.CinematicPlaying)
        {
            StartCoroutine(CinematicPlaying());
        }
        else
        {
            if (myJoint != null)
            {
                myJoint.enabled = true;
            }
            distanceSystem = true;
        }
        
        IEnumerator CinematicPlaying()
        {
            if (myJoint != null)
            {
                myJoint.enabled = false;
            }
            yield return new WaitForSeconds(0.5f);
            distanceSystem = false;
        }
    }

}
