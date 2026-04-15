using Unity.VisualScripting;
using UnityEngine;

public class FlowerSystem : PlayerMovement
{
    public GameObject flowerObject;
    public GameObject interactable;
    void Update()
    {
        if (flowerObject != null)
        {
            base.flowered = true;
            base.moveSpeed = 2.5f;
            base.JumpForce = 5f;
            animator.SetBool("Flowered", true);

        }
        else
        {
            base.flowered = false;
            base.moveSpeed = 5f;
            base.JumpForce = 7f;
            animator.SetBool("Flowered", false);

        }
        base.Update();
    }
}
