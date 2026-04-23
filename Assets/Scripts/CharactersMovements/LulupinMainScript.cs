using System;
using UnityEngine;

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
    [SerializeField]
    private Transform myTransform;
    public bool distanceSystem;
    void Update()
    {
        Physics2D.IgnoreCollision(playerBox, myBox);
        Physics2D.IgnoreCollision(playerCircle, myCircle);
        Physics2D.IgnoreCollision(playerCircle, myBox);
        Physics2D.IgnoreCollision(playerBox, myCircle);
        float distance = Vector3.Distance(vitalinaTransform.position, myTransform.position);
        if(distanceSystem)
        { 
            if (distance > 1.5)
            {
                // Retour à la base en priorité
                print("Retourner à Vitalina");
                myTransform.position = vitalinaTransform.position;
            }
        }
    }

}
